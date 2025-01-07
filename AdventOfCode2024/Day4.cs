
using System.Text.RegularExpressions;

class Day4 : IAlgorithms, IStars
{
    public Day4()
    {
        Star1();
        // Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);

        string regexXMAS = @"XMAS";
        string regexSAMX = @"SAMX";
        string line;

        // HORIZONTAL
        for (int y = 0; y < input.Count; y++)
        {
            long found = Regex.Matches(input[y], regexXMAS).Count + Regex.Matches(input[y], regexSAMX).Count;
            result += found;
            Console.WriteLine(input[y]);
            Console.WriteLine($"Found: {found}");
        }
        //

        Console.WriteLine();

        // VERTICAL
        for (int x = 0; x < input[0].Length; x++)
        {
            line = "";
            for (int y = 0; y < input.Count; y++)
            {
                line += input[y][x];
            }
            var matchesXMAS = Regex.Matches(line, regexXMAS);
            var matchesSAMX = Regex.Matches(line, regexSAMX);
            long found = matchesXMAS.Count + matchesSAMX.Count;
            result += found;
            Console.WriteLine(line);
            Console.WriteLine($"Found: {found}");
        }
        //

        Console.WriteLine();

        // DIAGONAL
        for (int y = input.Count - 1; y > 0; y--)
        {
            line = "";
            for (int x = 0; x < input[0].Length && y + x < input.Count; x++)
            {
                line += input[y + x][x];
            }
            var matchesXMAS = Regex.Matches(line, regexXMAS);
            var matchesSAMX = Regex.Matches(line, regexSAMX);
            long found = matchesXMAS.Count + matchesSAMX.Count;
            result += found;
            Console.WriteLine(line);
            Console.WriteLine($"Found: {found}");
        }

        for (int x = 0; x < input[0].Length; x++)
        {
            line = "";
            for (int y = 0; y < input.Count && y + x < input[0].Length; y++)
            {
                line += input[y][x + y];
            }
            var matchesXMAS = Regex.Matches(line, regexXMAS);
            var matchesSAMX = Regex.Matches(line, regexSAMX);
            long found = matchesXMAS.Count + matchesSAMX.Count;
            result += found;
            Console.WriteLine(line);
            Console.WriteLine($"Found: {found}");
        }
        //

        Console.WriteLine();

        // DIAGONAL BACKWARD
        for (int y = input.Count - 1; y > 0; y--)
        {
            line = "";
            for (int x = input[0].Length - 1; x > 0 && y + (input[0].Length - 1 - x) < input.Count; x--)
            {
                line += input[y + (input[0].Length - 1 - x)][x];
            }
            var matchesXMAS = Regex.Matches(line, regexXMAS);
            var matchesSAMX = Regex.Matches(line, regexSAMX);
            long found = matchesXMAS.Count + matchesSAMX.Count;
            result += found;
            Console.WriteLine(line);
            Console.WriteLine($"Found: {found}");
        }

        for (int x = input[0].Length - 1; x > 0; x--)
        {
            line = "";
            for (int y = 0; y < input.Count && x - y > 0; y++)
            {
                line += input[y][x - y];
            }
            var matchesXMAS = Regex.Matches(line, regexXMAS);
            var matchesSAMX = Regex.Matches(line, regexSAMX);
            long found = matchesXMAS.Count + matchesSAMX.Count;
            result += found;
            Console.WriteLine(line);
            Console.WriteLine($"Found: {found}");
        }
        //

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;



        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day4Star1Example1.txt");
        // Star1Algorithm("../../../Examples/Day4Star1Example2.txt");
        // Star1Algorithm("../../../Examples/Day4Star1Example3.txt");
        Star1Algorithm("../../../Examples/Day4Star1Example4.txt");

        // Star1Algorithm("../../../Input/Day4Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day4Star2Example1.txt");

        Star2Algorithm("../../../Input/Day4Star1.txt");
    }
}