
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
            result += Regex.Matches(input[y], regexXMAS).Count + Regex.Matches(input[y], regexSAMX).Count;
        }
        //

        // VERTICAL
        for (int x = 0; x < input[0].Length; x++)
        {
            line = "";
            for (int y = 0; y < input.Count; y++)
            {
                line += input[y][x];
            }
            result += Regex.Matches(line, regexXMAS).Count + Regex.Matches(line, regexSAMX).Count;
        }
        //

        // DIAGONAL
        for (int y = input.Count - 1; y > 0; y--)
        {
            line = "";
            for (int x = 0; x < input[0].Length && y + x < input.Count; x++)
            {
                line += input[y + x][x];
            }
            result += Regex.Matches(line, regexXMAS).Count + Regex.Matches(line, regexSAMX).Count;
        }

        for (int x = 0; x < input[0].Length; x++)
        {
            line = "";
            for (int y = 0; y < input.Count && y + x < input[0].Length; y++)
            {
                line += input[y][x + y];
            }
            result += Regex.Matches(line, regexXMAS).Count + Regex.Matches(line, regexSAMX).Count;
        }
        //

        // DIAGONAL BACKWARD
        for (int y = input.Count - 1; y > 0; y--)
        {
            line = "";
            for (int x = input[0].Length - 1; x > 0 && y + (input[0].Length - 1 - x) < input.Count; x--)
            {
                line += input[y + (input[0].Length - 1 - x)][x];
            }
            result += Regex.Matches(line, regexXMAS).Count + Regex.Matches(line, regexSAMX).Count;
        }

        for (int x = input[0].Length - 1; x > 0; x--)
        {
            line = "";
            for (int y = 0; y < input.Count && x - y > 0; y++)
            {
                line += input[y][x - y];
            }
            result += Regex.Matches(line, regexXMAS).Count + Regex.Matches(line, regexSAMX).Count;
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