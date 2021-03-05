namespace Challenge
{
  interface IPaymentOverviewGenerator<in TInput, out TResult>
  {
    TResult GenerateContent(TInput input);
  }
}