public class Anagram
{
    private readonly string _target;
    private readonly string _sortedTarget;

    public Anagram(string baseWord)
    {
        _target = baseWord;
        _sortedTarget = SortLetters(baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        return potentialMatches
            .Where(IsAnagram)
            .ToArray();
    }

    private bool IsAnagram(string candidate)
    {
        if (string.Equals(candidate, _target, StringComparison.OrdinalIgnoreCase))
            return false;

        return SortLetters(candidate) == _sortedTarget;
    }
    private static string SortLetters(string word)
    {
        var letters = word.ToLowerInvariant().ToCharArray();
        Array.Sort(letters);
        return new string(letters);
    }
}