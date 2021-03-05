namespace Challenge
{
  class PaymentOverviewParams
  {
    public decimal LoanAmount { get; set; }
    public int DurationInYears { get; set; }
    public decimal InterestRate { get; set; }
    public decimal Installment { get; set; }
    public decimal LoanCost { get; set; }
    public decimal AdministrationFee { get; set; }
  }
}