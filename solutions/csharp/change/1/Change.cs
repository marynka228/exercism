public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException("Сума не може бути від'ємною.");

        if (target == 0)
            return Array.Empty<int>();

        var minCoins = new int[target + 1];
        // lastCoin[a] остання монета в оптимальному розкладі суми a
        var lastCoin = new int[target + 1];

        for (int amount = 1; amount <= target; amount++)
        {
            minCoins[amount] = -1;

            foreach (int coin in coins)
            {
                if (coin <= 0 || coin > amount)
                    continue;

                int previous = minCoins[amount - coin];
                if (previous < 0)
                    continue;

                if (minCoins[amount] == -1 || previous + 1 < minCoins[amount])
                {
                    minCoins[amount] = previous + 1;
                    lastCoin[amount] = coin;
                }
            }
        }

        if (minCoins[target] == -1)
            throw new ArgumentException("Неможливо видати таку суму цими монетами.");

        var result = new List<int>();
        for (int amount = target; amount > 0; amount -= lastCoin[amount])
            result.Add(lastCoin[amount]);

        result.Sort();
        return result.ToArray();
    }
}