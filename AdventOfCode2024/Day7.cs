class Day7 : IAlgorithms, IStars
{
    public Day7()
    {
        Star1();
        Star2();
    }

    List<string> GenerateCombinations(string input, int length)
    {
        if (string.IsNullOrEmpty(input) || length <= 0)
            return new List<string>();

        List<string> combinations = new List<string>();
        GenerateCombinationsRecursive(input, length, "", combinations);

        return combinations;
    }

    void GenerateCombinationsRecursive(string input, int length, string current, List<string> results)
    {
        if (current.Length == length)
        {
            results.Add(current);
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            GenerateCombinationsRecursive(input, length, current + input[i], results);
        }
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);
        
        List<Tuple<long, List<long>>> calibrationEquations = new List<Tuple<long, List<long>>>();
        foreach (var line in input)
        {
            var temp = line.Split(": ");
            var temp2 = temp[1].Split(' ');
            var temp3 = new List<long>();
            foreach (var value in temp2) {
                temp3.Add(Convert.ToInt64(value));
            }
            calibrationEquations.Add(new Tuple<long, List<long>>(Convert.ToInt64(temp[0]), temp3));
        }

        string allowedOperators = "+*";

        foreach (var calibrationEquation in calibrationEquations)
        {
            var possibleCombinations = GenerateCombinations(allowedOperators, calibrationEquation.Item2.Count - 1);
            foreach (var possibleCombination in possibleCombinations) {
                long tempResult = calibrationEquation.Item2[0];
                for (int i = 0; i < possibleCombination.Length; i++)
                {
                    if (possibleCombination[i] == '+') {
                        tempResult += calibrationEquation.Item2[i + 1];
                    } else {
                        tempResult *= calibrationEquation.Item2[i + 1];
                    }

                    if (tempResult > calibrationEquation.Item1) {
                        break;
                    }
                }

                if (tempResult == calibrationEquation.Item1) {
                    result += calibrationEquation.Item1;
                    break;
                }
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);

        List<Tuple<long, List<long>>> calibrationEquations = new List<Tuple<long, List<long>>>();
        foreach (var line in input)
        {
            var temp = line.Split(": ");
            var temp2 = temp[1].Split(' ');
            var temp3 = new List<long>();
            foreach (var value in temp2) {
                temp3.Add(Convert.ToInt64(value));
            }
            calibrationEquations.Add(new Tuple<long, List<long>>(Convert.ToInt64(temp[0]), temp3));
        }

        string allowedOperators = "+*|";

        foreach (var calibrationEquation in calibrationEquations)
        {
            var possibleCombinations = GenerateCombinations(allowedOperators, calibrationEquation.Item2.Count - 1);
            foreach (var possibleCombination in possibleCombinations) {
                long tempResult = calibrationEquation.Item2[0];
                for (int i = 0; i < possibleCombination.Length; i++)
                {
                    if (possibleCombination[i] == '+') {
                        tempResult += calibrationEquation.Item2[i + 1];
                    } else if (possibleCombination[i] == '*') {
                        tempResult *= calibrationEquation.Item2[i + 1];
                    } else {
                        tempResult = Convert.ToInt64(tempResult.ToString() + calibrationEquation.Item2[i + 1].ToString());
                    }

                    if (tempResult > calibrationEquation.Item1) {
                        break;
                    }
                }

                if (tempResult == calibrationEquation.Item1) {
                    result += calibrationEquation.Item1;
                    break;
                }
            }
        }

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day7Star1Example1.txt");

        Star1Algorithm("../../../Input/Day7Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day7Star1Example1.txt");

        Star2Algorithm("../../../Input/Day7Star1.txt");
    }
}