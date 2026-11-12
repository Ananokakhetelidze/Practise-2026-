using StringAnalysis.App;

namespace StringAnalysis.Tests;

[TestFixture]
public class MaxIdenticalDigitsTests
{
    // Boundary values: length 0, 1, 2
    [TestCase("", 0, TestName = "Digits_EmptyString_Returns0")]
    [TestCase("7", 1, TestName = "Digits_SingleDigit_Returns1")]
    [TestCase("77", 2, TestName = "Digits_TwoEqualDigits_Returns2")]
    [TestCase("78", 1, TestName = "Digits_TwoDifferentDigits_Returns1")]
    // Boundary values: smallest and largest digit
    [TestCase("000", 3, TestName = "Digits_ZeroRun_Counted")]
    [TestCase("999", 3, TestName = "Digits_NineRun_Counted")]
    // Partition: no ASCII digits
    [TestCase("abc", 0, TestName = "Digits_OnlyLetters_Returns0")]
    [TestCase("!@# ", 0, TestName = "Digits_OnlySymbolsAndSpaces_Returns0")]
    [TestCase("٣٣٣", 0, TestName = "Digits_ArabicIndicDigits_Returns0")]
    // Partition: all different digits
    [TestCase("1234", 1, TestName = "Digits_AllDifferent_Returns1")]
    // Partition: all identical digits
    [TestCase("5555", 4, TestName = "Digits_AllIdentical_ReturnsLength")]
    // Partition: longest run at start / middle / end
    [TestCase("333a1", 3, TestName = "Digits_LongestRunAtStart")]
    [TestCase("1a333b2", 3, TestName = "Digits_LongestRunInMiddle")]
    [TestCase("12333", 3, TestName = "Digits_LongestRunAtEnd")]
    // Partition: runs broken / surrounded by non-digits
    [TestCase("33a33", 2, TestName = "Digits_RunBrokenByLetter")]
    [TestCase("1 1", 1, TestName = "Digits_RunBrokenBySpace")]
    [TestCase("aaaa11", 2, TestName = "Digits_LongerLetterRunIsIgnored")]
    [TestCase("-1.11", 2, TestName = "Digits_SignAndDecimalPointNotDigits")]
    public void MaxIdenticalDigits_ReturnsExpected(string input, int expected)
    {
        // Arrange - input provided by TestCase

        // Act
        int result = StringAnalyzer.MaxIdenticalDigits(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MaxIdenticalDigits_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null!;

        // Act
        TestDelegate act = () => StringAnalyzer.MaxIdenticalDigits(input);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Test]
    public void MaxIdenticalDigits_VeryLongRun_ReturnsLength()
    {
        // Arrange
        string input = new string('9', 10_000);

        // Act
        int result = StringAnalyzer.MaxIdenticalDigits(input);

        // Assert
        Assert.That(result, Is.EqualTo(10_000));
    }
}
