public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2)
            throw new ArgumentException("Вхідна основа має бути не менше 2.", nameof(inputBase));

        if (outputBase < 2)
            throw new ArgumentException("Вихідна основа має бути не менше 2.", nameof(outputBase));

        if (inputDigits == null)
            throw new ArgumentException("Цифри не можуть бути null.", nameof(inputDigits));

        // Крок 1: цифри вхідної основи -> звичайне число
        long value = 0;
        foreach (int digit in inputDigits)
        {
            if (digit < 0 || digit >= inputBase)
                throw new ArgumentException("Цифра виходить за межі вхідної основи.", nameof(inputDigits));

            value = checked(value * inputBase + digit);
        }

        // Крок 2: число -> цифри вихідної основи
        if (value == 0)
            return new[] { 0 };

        var result = new List<int>();
        while (value > 0)
        {
            result.Add((int)(value % outputBase));
            value /= outputBase;
        }

        result.Reverse();
        return result.ToArray();
    }
}