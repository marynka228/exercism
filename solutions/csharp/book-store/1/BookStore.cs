public static class BookStore
{
    private static readonly int[] GroupPrice = { 0, 800, 1520, 2160, 2560, 3000 };

    public static decimal Total(IEnumerable<int> books)
    {
        var counts = books
            .GroupBy(b => b)
            .Select(g => g.Count())
            .ToArray();

        var cache = new Dictionary<string, int>();
        return Cheapest(counts, cache) / 100m;
    }

    private static int Cheapest(int[] counts, Dictionary<string, int> cache)
    {
        var state = counts
            .Where(c => c > 0)
            .OrderByDescending(c => c)
            .ToArray();

        if (state.Length == 0)
            return 0;

        var key = string.Join(",", state);
        if (cache.TryGetValue(key, out int cached))
            return cached;

        int best = int.MaxValue;

        for (int k = 1; k <= state.Length; k++)
        {
            var next = (int[])state.Clone();

            for (int i = 0; i < k; i++)
                next[i]--;

            best = Math.Min(best, GroupPrice[k] + Cheapest(next, cache));
        }

        cache[key] = best;
        return best;
    }
}