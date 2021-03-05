namespace Challenge
{
  static class LoanCalculator
  {
    private const int MonthsInYear = 12;

    public static decimal Installment(decimal loanAmount, decimal interestRate, int durationInYears, int paidInstallments = 12)
    {
      int totalInstallments = durationInYears * MonthsInYear;
      interestRate /= 100;

      return
        (loanAmount * interestRate) /
        (paidInstallments * (1 - DecimalHelper.Pow(paidInstallments / (paidInstallments + interestRate), totalInstallments)));
    }

    public static decimal LoanCost(decimal loanAmount, decimal installment, int durationInYears)
    {
      return (durationInYears * MonthsInYear * installment) - loanAmount;
    }

    public static decimal AdministrationFee(decimal loanAmount, LoanConfiguration.LoanFeeConfiguration feeConfiguration)
    {
      decimal percentageCharge = loanAmount * (feeConfiguration.Percentage / 100);
      return percentageCharge >= feeConfiguration.Charge ? feeConfiguration.Charge : percentageCharge;
    }
  }
}