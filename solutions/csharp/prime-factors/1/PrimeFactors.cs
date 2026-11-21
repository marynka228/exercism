public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var factors = new List<long>();

        for (long divisor = 2; divisor <= number / divisor; divisor++)
        {
            while (number % divisor == 0)
            {
                factors.Add(divisor);
                number /= divisor;
            }
        }

        if (number > 1)
            factors.Add(number);

        return factors.ToArray();
    }
}