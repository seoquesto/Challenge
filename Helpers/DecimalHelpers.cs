namespace Challenge
{
  static class DecimalHelper
  {
    public static decimal Pow(decimal x, int y)
    {
      decimal result = 1M;

      for (int i = 0; i < y; i++)
      {
        result *= x;
      }

      return result;
    }
  }
}