public static class Wordy
{
    public static int Answer(string question)
    {
        if (question == null)
            throw new ArgumentException("Запитання не може бути null.");

        string text = question.Trim();

        const string prefix = "What is";
        if (!text.StartsWith(prefix, StringComparison.Ordinal) || !text.EndsWith("?"))
            throw new ArgumentException("Непідтримуване запитання.");

        string body = text.Substring(prefix.Length, text.Length - prefix.Length - 1);

    
        body = body.Replace("multiplied by", "multiplied")
                   .Replace("divided by", "divided");

        var tokens = body.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length == 0)
            throw new ArgumentException("Немає виразу.");

        int index = 0;
        int result = ParseNumber(tokens[index++]);

        while (index < tokens.Length)
        {
            string op = tokens[index++];

            if (index >= tokens.Length)
                throw new ArgumentException("Після операції немає числа.");

            int operand = ParseNumber(tokens[index++]);

            switch (op)
            {
                case "plus":
                    result = checked(result + operand);
                    break;
                case "minus":
                    result = checked(result - operand);
                    break;
                case "multiplied":
                    result = checked(result * operand);
                    break;
                case "divided":
                    if (operand == 0)
                        throw new ArgumentException("Ділення на нуль.");
                    result /= operand;
                    break;
                default:
                    throw new ArgumentException("Непідтримувана операція.");
            }
        }

        return result;
    }

    private static int ParseNumber(string token)
    {
        if (!int.TryParse(token, out int value))
            throw new ArgumentException("Очікувалось число.");
        return value;
    }
}