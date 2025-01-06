
using System.Text.RegularExpressions;

class Day3 : IAlgorithms, IStars
{
    public Day3() {
        Star1();
        Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var programLines = IAlgorithms.LoadLines(filePath);

        foreach (var line in programLines)
        {
            var regexMatches = Regex.Matches(line, @"(?<=mul\()\d+,\d+(?=\))");

            foreach (Match mulInstruction in regexMatches)
            {
                var values = mulInstruction.Value.Split(',');
                result += Convert.ToInt64(values[0]) * Convert.ToInt64(values[1]);
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        long matches = 0, doCommands = 0, dontCommands = 0;

        var programLines = IAlgorithms.LoadLines(filePath);

        bool doCommand = true;
        foreach (var line in programLines)
        {
            var regexMatches = Regex.Matches(line, @"(?<=mul\()\d+,\d+(?=\))|do\(\)|don't\(\)");

            matches += regexMatches.Count;

            foreach (Match mulInstruction in regexMatches)
            {
                switch (mulInstruction.Value)
                {
                    case "do()":
                        doCommand = true;
                        ++doCommands;
                        break;
                    case "don't()":
                        doCommand = false;
                        ++dontCommands;
                        break;
                    default:
                        if (doCommand) {
                            var values = mulInstruction.Value.Split(',');
                            result += Convert.ToInt64(values[0]) * Convert.ToInt64(values[1]);
                        }
                        break;
                }
            }
        }

        Console.WriteLine($"Matches: {matches}, Do(): {doCommands}, Don't(): {dontCommands}");
        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1() {
        // Star1Algorithm("../../../Examples/Day3Star1Example1.txt");

        Star1Algorithm("../../../Input/Day3Star1.txt");
    }

    public void Star2() {
        // Star2Algorithm("../../../Examples/Day3Star2Example1.txt");

        Star2Algorithm("../../../Input/Day3Star1.txt");
    }
}