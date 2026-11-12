using StringAnalysis.App;

namespace StringAnalysis.Tests;

[TestFixture]
public class MaxIdenticalLatinLettersTests
{
    // Boundary values: length 0, 1, 2
    [TestCase("", 0, TestName = "Latin_EmptyString_Returns0")]
    [TestCase("a", 1, TestName = "Latin_SingleLetter_Returns1")]
    [TestCase("aa", 2, TestName = "Latin_TwoEqualLetters_Returns2")]
    [TestCase("ab", 1, TestName = "Latin_TwoDifferentLetters_Returns1")]
    // Partition: no Latin letters at all
    [TestCase("1234", 0, TestName = "Latin_OnlyDigits_Returns0")]
    [TestCase("!!!   ", 0, TestName = "Latin_OnlySymbolsAndSpaces_Returns0")]
    [TestCase("ааа", 0, TestName = "Latin_CyrillicLetters_Returns0")]
    [TestCase("ééé", 0, TestName = "Latin_AccentedLetters_Returns0")]
    // Partition: all identical letters
    [TestCase("zzzz", 4, TestName = "Latin_AllIdenticalLowercase_ReturnsLength")]
    [TestCase("ZZZ", 3, TestName = "Latin_AllIdenticalUppercase_ReturnsLength")]
    // Partition: longest run at start / middle / end
    [TestCase("aaab", 3, TestName = "Latin_LongestRunAtStart")]
    [TestCase("baaab", 3, TestName = "Latin_LongestRunInMiddle")]
    [TestCase("baaa", 3, TestName = "Latin_LongestRunAtEnd")]
    // Partition: case sensitivity
    [TestCase("aaAA", 2, TestName = "Latin_CaseSensitive_UpperAndLowerDiffer")]
    // Partition: runs broken / surrounded by non-letters
    [TestCase("aa1aaa", 3, TestName = "Latin_RunBrokenByDigit")]
    [TestCase("aa aa", 2, TestName = "Latin_RunBrokenBySpace")]
    [TestCase("11bb22", 2, TestName = "Latin_LettersBetweenDigits")]
    [TestCase("111aa", 2, TestName = "Latin_LongerDigitRunIsIgnored")]
    [TestCase("aaаaa", 2, TestName = "Latin_RunBrokenByCyrillicLookalike")]
    public void MaxIdenticalLatinLetters_ReturnsExpected(string input, int expected)
    {
        // Arrange - input provided by TestCase

        // Act
        int result = StringAnalyzer.MaxIdenticalLatinLetters(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MaxIdenticalLatinLetters_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null!;

        // Act
        TestDelegate act = () => StringAnalyzer.MaxIdenticalLatinLetters(input);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Test]
    public void MaxIdenticalLatinLetters_VeryLongRun_ReturnsLength()
    {
        // Arrange
        string input = new string('x', 10_000);

        // Act
        int result = StringAnalyzer.MaxIdenticalLatinLetters(input);

        // Assert
        Assert.That(result, Is.EqualTo(10_000));
    }
}
