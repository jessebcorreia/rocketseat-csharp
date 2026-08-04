using CashFlow.Domain;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);
        if (expenses.Count == 0)
        {
            return [];
        }

        using var workbook = new XLWorkbook();

        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);
        InsertData(worksheet, expenses);

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }

    private string ToDisplayString(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.ElectronicTransfer => ResourceReportGeneratorMessages.PAYMENT_TYPE_ELECTRONIC_TRANSFER,
            PaymentType.CreditCard => ResourceReportGeneratorMessages.PAYMENT_TYPE_CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportGeneratorMessages.PAYMENT_TYPE_DEBIT_CARD,
            PaymentType.Cash => ResourceReportGeneratorMessages.PAYMENT_TYPE_CASH,
            _ => string.Empty,
        };
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGeneratorMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGeneratorMessages.DESCRIPTION;
        worksheet.Cell("C1").Value = ResourceReportGeneratorMessages.DATE;
        worksheet.Cell("D1").Value = ResourceReportGeneratorMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGeneratorMessages.PAYMENT_TYPE;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }

    private void InsertData(IXLWorksheet worksheet, List<Expense> expenses)
    {
        var raw = 2;
        foreach (var expense in expenses)
        {
            worksheet.Cell($"A{raw}").Value = expense.Title;
            worksheet.Cell($"B{raw}").Value = expense.Description;
            worksheet.Cell($"C{raw}").Value = expense.Date;
            worksheet.Cell($"D{raw}").Value = expense.Amount;
            worksheet.Cell($"E{raw}").Value = ToDisplayString(expense.PaymentType);
            raw++;
        }

        worksheet.Columns().AdjustToContents();
    }
}
