public static class Bob
{
    public static string Response(string statement)
    {
        string text = statement?.Trim() ?? string.Empty;

        if (text.Length == 0)
            return "Fine. Be that way!";

        bool isQuestion = text.EndsWith("?");
        bool isShouting = text.Any(char.IsLetter) && text == text.ToUpperInvariant();

        if (isShouting && isQuestion)
            return "Calm down, I know what I'm doing!";

        if (isShouting)
            return "Whoa, chill out!";

        if (isQuestion)
            return "Sure.";

        return "Whatever.";
    }
}