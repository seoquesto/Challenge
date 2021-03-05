using System;
using System.Globalization;
using System.Threading;

namespace Challenge
{
  class Program
  {
    static void Main(string[] args)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
      
      IPaymentOverviewGenerator<PaymentOverviewParams, string> paymentOverviewGenerator = new DefaultConsolePaymentOverviewGenerator();
      IPaymentOverviewSender<PaymentOverviewParams> paymentOverview = new ConsolePaymentOverviewSender<PaymentOverviewParams>(paymentOverviewGenerator);
      IConfigurationManager configurationManager = new WindowsConfigurationManager();
      LoanConfiguration configuration = configurationManager.GetConfiguration();
      int attempt = 0;

      DisplayBanner();
      while (true)
      {
        attempt++;
        decimal loanAmount;
        int durationInYears;
        try
        {
          DisplayAttempt(attempt);

          Console.Write("Loan amount: ");
          loanAmount = Decimal.Parse(Console.ReadLine());

          if (loanAmount < 0)
          {
            throw new Exception("Loan amount value cannot be smaller then 0.");
          }

          Console.Write("Duration in years: ");
          durationInYears = Int32.Parse(Console.ReadLine());

          if (durationInYears < 0)
          {
            throw new Exception("Duration in years value cannot be smaller then 0.");
          }
        }
        catch (Exception ex)
        {
          DisplayParsingError(ex.Message);
          continue;
        }

        decimal interestRate = configuration.AnnualInterestRate;
        var installment = LoanCalculator.Installment(loanAmount, interestRate, durationInYears);
        var loanCost = LoanCalculator.LoanCost(loanAmount, installment, durationInYears);
        var administrationFee = LoanCalculator.AdministrationFee(loanAmount, configuration.LoanFee);

        PaymentOverviewParams overviewParams = new PaymentOverviewParams
        {
          LoanAmount = loanAmount,
          DurationInYears = durationInYears,
          Installment = installment,
          LoanCost = loanCost,
          InterestRate = interestRate,
          AdministrationFee = administrationFee,
        };
        Console.WriteLine();
        paymentOverview.Send(overviewParams);
      }
    }

    private static void DisplayBanner()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("#############################");
      Console.WriteLine("#======Loan calculator======#");
      Console.WriteLine("#############################");
      Console.ResetColor();
    }

    private static void DisplayAttempt(int attempt)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($"\nAttempt {attempt}");
      Console.ResetColor();
    }

    private static void DisplayParsingError(string message)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(message);
      Console.ResetColor();
      Console.WriteLine();
    }
  }
}
