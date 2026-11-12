namespace StringAnalysis.App;

/// <summary>
/// String analysis functions. All comparisons are case-sensitive ('a' != 'A').
/// </summary>
public static class StringAnalyzer
{
    /// <summary>
    /// Returns the length of the longest run of characters in which every character
    /// differs from the one before it. Empty string returns 0.
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="input"/> is null.</exception>
    public static int MaxUnequalConsecutive(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        if (input.Length == 0) return 0;

        int max = 1, current = 1;
        for (int i = 1; i < input.Length; i++)
        {
            current = input[i] != input[i - 1] ? current + 1 : 1;
            max = Math.Max(max, current);
        }
        return max;
    }

    /// <summary>
    /// Returns the length of the longest run of identical Latin letters (a-z, A-Z only).
    /// Returns 0 if the string contains no Latin letters.
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="input"/> is null.</exception>
    public static int MaxIdenticalLatinLetters(string input) =>
        MaxIdenticalRun(input, char.IsAsciiLetter);

    /// <summary>
    /// Returns the length of the longest run of identical digits (0-9 only).
    /// Returns 0 if the string contains no digits.
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="input"/> is null.</exception>
    public static int MaxIdenticalDigits(string input) =>
        MaxIdenticalRun(input, char.IsAsciiDigit);

    private static int MaxIdenticalRun(string input, Func<char, bool> isCounted)
    {
        ArgumentNullException.ThrowIfNull(input);

        int max = 0, current = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (!isCounted(input[i]))
            {
                current = 0;
                continue;
            }

            current = (i > 0 && input[i] == input[i - 1]) ? current + 1 : 1;
            max = Math.Max(max, current);
        }
        return max;
    }
}
