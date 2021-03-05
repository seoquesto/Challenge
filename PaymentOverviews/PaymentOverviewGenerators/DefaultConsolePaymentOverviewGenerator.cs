using System.Text;

namespace Challenge
{
  class DefaultConsolePaymentOverviewGenerator : IPaymentOverviewGenerator<PaymentOverviewParams, string>
  {
    public string GenerateContent(PaymentOverviewParams overviewParams)
    {
      return new StringBuilder()
        .Append("The payment overview")
        .AppendLine()
        .AppendFormat("Loan amount: {0:C}", overviewParams.LoanAmount)
        .AppendLine()
        .Append($"Duration: {overviewParams.DurationInYears} years")
        .AppendLine()
        .Append($"Interest rate: {overviewParams.InterestRate}%")
        .AppendLine()
        .AppendFormat("Monthly cost: {0:C}", overviewParams.Installment)
        .AppendLine()
        .AppendFormat("Cost of loan: {0:C}", overviewParams.LoanCost)
        .AppendLine()
        .AppendFormat("Administration fee: {0:C}", overviewParams.AdministrationFee)
        .AppendLine()
        .ToString();
    }
  }
}