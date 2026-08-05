using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Extensions;

public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
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
}
