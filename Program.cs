using StringAnalysis.App;

Console.Write("Enter a string: ");
string input = Console.ReadLine() ?? string.Empty;

Console.WriteLine($"Max unequal consecutive chars:   {StringAnalyzer.MaxUnequalConsecutive(input)}");
Console.WriteLine($"Max identical Latin letters:     {StringAnalyzer.MaxIdenticalLatinLetters(input)}");
Console.WriteLine($"Max identical digits:            {StringAnalyzer.MaxIdenticalDigits(input)}");