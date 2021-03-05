namespace Challenge
{
  interface IPaymentOverviewSender<in TInput>
  {
    void Send(TInput input);
  }
}