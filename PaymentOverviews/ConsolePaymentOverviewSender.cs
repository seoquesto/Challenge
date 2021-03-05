using System;

namespace Challenge
{
  class ConsolePaymentOverviewSender<TInput> : IPaymentOverviewSender<TInput>
  {
    private readonly IPaymentOverviewGenerator<TInput, string> _paymentOverviewGenerator;

    public ConsolePaymentOverviewSender(IPaymentOverviewGenerator<TInput, string> paymentOverviewGenerator)
    {
      this._paymentOverviewGenerator = paymentOverviewGenerator;
    }

    public void Send(TInput input)
    {
      var content = this._paymentOverviewGenerator.GenerateContent(input);
      Console.Write(content);
    }
  }
}