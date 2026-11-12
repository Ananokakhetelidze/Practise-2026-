using StringAnalysis.App;

namespace StringAnalysis.Tests;

[TestFixture]
public class MaxUnequalConsecutiveTests
{
    // Boundary values: length 0, 1, 2
    [TestCase("", 0, TestName = "Unequal_EmptyString_Returns0")]
    [TestCase("a", 1, TestName = "Unequal_SingleChar_Returns1")]
    [TestCase("aa", 1, TestName = "Unequal_TwoEqualChars_Returns1")]
    [TestCase("ab", 2, TestName = "Unequal_TwoDifferentChars_Returns2")]
    // Partition: all characters identical
    [TestCase("aaaa", 1, TestName = "Unequal_AllIdentical_Returns1")]
    // Partition: no two neighbours equal (whole string counts)
    [TestCase("abcd", 4, TestName = "Unequal_AllDifferent_ReturnsLength")]
    [TestCase("abab", 4, TestName = "Unequal_Alternating_ReturnsLength")]
    // Partition: mixed, longest run at start / middle / end
    [TestCase("abcdd", 4, TestName = "Unequal_LongestRunAtStart")]
    [TestCase("aabcdd", 4, TestName = "Unequal_LongestRunInMiddle")]
    [TestCase("aabcd", 4, TestName = "Unequal_LongestRunAtEnd")]
    [TestCase("aabbc", 2, TestName = "Unequal_SeveralEqualShortRuns")]
    // Partition: character classes - every character counts, case-sensitive
    [TestCase("aA", 2, TestName = "Unequal_CaseSensitive_UpperAndLowerDiffer")]
    [TestCase("a b", 3, TestName = "Unequal_SpacesCountAsCharacters")]
    [TestCase("1!a", 3, TestName = "Unequal_DigitsAndSymbolsCount")]
    [TestCase("  ", 1, TestName = "Unequal_OnlySpaces_Returns1")]
    public void MaxUnequalConsecutive_ReturnsExpected(string input, int expected)
    {
        // Arrange - input provided by TestCase

        // Act
        int result = StringAnalyzer.MaxUnequalConsecutive(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MaxUnequalConsecutive_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null!;

        // Act
        TestDelegate act = () => StringAnalyzer.MaxUnequalConsecutive(input);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Test]
    public void MaxUnequalConsecutive_VeryLongAlternatingString_ReturnsLength()
    {
        // Arrange
        string input = string.Concat(Enumerable.Repeat("ab", 5_000));

        // Act
        int result = StringAnalyzer.MaxUnequalConsecutive(input);

        // Assert
        Assert.That(result, Is.EqualTo(10_000));
    }
}
