namespace Challenge
{
  class LoanConfiguration
  {
    public decimal AnnualInterestRate { get; set; }
    public LoanFeeConfiguration LoanFee { get; set; }

    public class LoanFeeConfiguration
    {
      public decimal Percentage { get; set; }
      public decimal Charge { get; set; }
    }
  }
}