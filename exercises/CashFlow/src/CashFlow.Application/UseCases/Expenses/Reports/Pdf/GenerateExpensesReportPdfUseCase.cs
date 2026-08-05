using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Colors;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Extensions;
using CashFlow.Domain.Repositories.Expenses;
// using DocumentFormat.OpenXml.Spreadsheet;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf;

public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private const int ROW_HEIGHT_EXPENSE_TABLE = 25;


    public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);
        if (expenses.Count == 0)
        {
            return [];
        }

        var totalExpenses = expenses.Sum(expenses => expenses.Amount);
        var document = CreateDocument(month);
        var page = CreatePage(document);

        CreateHeaderWithLogoAndTitle(page);
        CreateTotalExpensesSection(page, month, totalExpenses);

        foreach (var expense in expenses)
        {
            var table = CreateExpenseTable(page, expense);
        }

        return RenderDocument(document);
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        document.Info.Title = $"ResourceReportGeneratorMessages.EXPENSES_FOR {month:Y}";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;

        return document;
    }

    private Section CreatePage(Document document)
    {
        var section = document.AddSection();
        section.PageSetup = document.DefaultPageSetup.Clone();
        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.LeftMargin = 40;
        section.PageSetup.RightMargin = 40;
        section.PageSetup.TopMargin = 40;
        section.PageSetup.BottomMargin = 40;

        return section;
    }

    private void CreateHeaderWithLogoAndTitle(Section page)
    {
        var table = page.AddTable();
        table.AddColumn();
        table.AddColumn("300").Format.Alignment = ParagraphAlignment.Left;

        var row = table.AddRow();

        var assembly = Assembly.GetExecutingAssembly();
        var directoryName = Path.GetDirectoryName(assembly.Location);
        var filePath = Path.Combine(directoryName!, "Logo", "logo.png");
        var image = row.Cells[0].AddImage(filePath);
        image.LockAspectRatio = true;
        image.Width = "60";

        row.Cells[1].AddParagraph(ResourceReportGeneratorMessages.EXPENSES_REPORT_TITLE);
        row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 16 };
        row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
    }

    private void CreateTotalExpensesSection(Section page, DateOnly month, decimal totalExpenses)
    {
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";

        var title = string.Format(ResourceReportGeneratorMessages.TOTAL_SPENT_IN, month.ToString("Y")); // minha string {0} <- formata o parâmetro

        paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
        paragraph.AddLineBreak();
        paragraph.AddFormattedText($"R$ {totalExpenses}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
    }

    private Table CreateExpenseTable(Section page, Expense expense)
    {
        var table = page.AddTable();
        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

        var row = table.AddRow();
        row.Height = ROW_HEIGHT_EXPENSE_TABLE;

        // Header Row
        AddExpenseTitle(row.Cells[0], expense.Title);
        AddHeaderForAmount(row.Cells[3]);

        // Information Row
        row = table.AddRow();
        row.Height = ROW_HEIGHT_EXPENSE_TABLE;
        row.Cells[0].Format.LeftIndent = "20";
        AddExpenseInformation(row.Cells[0], expense.Date.ToString("D"));
        AddExpenseInformation(row.Cells[1], expense.Date.ToString("t"));
        AddExpenseInformation(row.Cells[2], expense.PaymentType.PaymentTypeToString());
        AddAmountForExpense(row.Cells[3], expense.Amount);

        // Description Row
        if (string.IsNullOrEmpty(expense.Description) == false)
        {
            AddDescriptionRow(table, expense.Description, row.Cells[3]);
        }

        // Separator
        AddWhiteSpace(table);
        return table;
    }

    private void AddExpenseTitle(Cell cell, string expenseTitle)
    {
        cell.AddParagraph(expenseTitle);
        cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.BLACK };
        cell.Shading.Color = ColorsHelper.RED_LIGHT;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.Format.LeftIndent = "20";
        cell.MergeRight = 2;
    }

    private void AddHeaderForAmount(Cell cell)
    {
        cell.AddParagraph(ResourceReportGeneratorMessages.AMOUNT);
        cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.WHITE };
        cell.Shading.Color = ColorsHelper.RED_DARK;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddExpenseInformation(Cell cell, string data)
    {
        cell.AddParagraph(data);
        cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12, Color = ColorsHelper.BLACK };
        cell.Shading.Color = ColorsHelper.GREEN_DARK;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddAmountForExpense(Cell cell, decimal amount)
    {
        cell.AddParagraph($"-{amount}");
        cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 14, Color = ColorsHelper.BLACK };
        cell.Shading.Color = ColorsHelper.WHITE;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddWhiteSpace(Table table)
    {
        var row = table.AddRow();
        row.Height = ROW_HEIGHT_EXPENSE_TABLE;
        row.Borders.Visible = false;
    }

    private void AddDescriptionRow(Table table, string description, Cell previousRow)
    {
        var row = table.AddRow();
        row.Height = ROW_HEIGHT_EXPENSE_TABLE;
        row.Cells[0].AddParagraph(description);

        row.Cells[0].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 10, Color = ColorsHelper.BLACK };
        row.Cells[0].Shading.Color = ColorsHelper.GREEN_LIGHT;
        row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
        row.Cells[0].Format.LeftIndent = "20";
        row.Cells[0].MergeRight = 2;

        previousRow.MergeDown = 1;
    }

    private byte[] RenderDocument(Document document)
    {
        var renderer = new PdfDocumentRenderer
        {
            Document = document
        };

        renderer.RenderDocument();

        using var file = new MemoryStream();
        renderer.PdfDocument.Save(file);

        return file.ToArray();
    }
}
