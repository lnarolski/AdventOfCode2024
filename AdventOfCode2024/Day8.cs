class Day8 : IAlgorithms, IStars
{
    public Day8()
    {
        Star1();
        Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadCharGrid(filePath);

        Dictionary<char, List<Tuple<int, int>>> frequencies = new Dictionary<char, List<Tuple<int, int>>>();
        for (int y = 0; y < input.Count; y++) {
            for (int x = 0; x < input[y].Length; x++) {
                if (input[y][x] != '.') {
                    if (!frequencies.ContainsKey(input[y][x])) {
                        frequencies.Add(input[y][x], new List<Tuple<int, int>>());
                    }

                    frequencies[input[y][x]].Add(new Tuple<int, int>(y, x));
                }
            }
        }

        foreach (var frequency in frequencies)
        {
            for (int i = 0; i < frequency.Value.Count; ++i) {
                for (int j = 0; j < frequency.Value.Count; ++j) {
                    if (i == j) {
                        continue;
                    }

                    int xDistance = Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);
                    int yDistance = Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                    if (frequency.Value[i].Item2 <= frequency.Value[j].Item2) { // i left
                        if (frequency.Value[i].Item1 >= frequency.Value[j].Item1) { // i down
                            if (frequency.Value[i].Item1 + yDistance < input.Count &&
                                frequency.Value[i].Item2 - xDistance >= 0 &&
                                input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 - xDistance] != '#') {
                                input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 - xDistance] = '#';
                                ++result;
                            }
                            if (frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                frequency.Value[j].Item1 - yDistance >= 0 &&
                                input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 + xDistance] != '#') {
                                input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 + xDistance] = '#';
                                ++result;
                            }
                        } else {  // i up
                            if (frequency.Value[i].Item1 - yDistance >= 0 &&
                                frequency.Value[i].Item2 - xDistance >= 0 &&
                                input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 - xDistance] != '#') {
                                input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 - xDistance] = '#';
                                ++result;
                            }
                            if (frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                frequency.Value[j].Item1 + yDistance < input.Count &&
                                input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 + xDistance] != '#') {
                                input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 + xDistance] = '#';
                                ++result;
                            }
                        }
                    } else { // i right
                        if (frequency.Value[i].Item1 >= frequency.Value[j].Item1) { // i down
                            if (frequency.Value[i].Item1 + yDistance < input.Count &&
                                frequency.Value[i].Item2 + xDistance < input[0].Length &&
                                input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 + xDistance] != '#') {
                                input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 + xDistance] = '#';
                                ++result;
                            }
                            if (frequency.Value[j].Item2 - xDistance >= 0 &&
                                frequency.Value[j].Item1 - yDistance >= 0 &&
                                input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 - xDistance] != '#') {
                                input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 - xDistance] = '#';
                                ++result;
                            }
                        } else {  // i up
                            if (frequency.Value[i].Item1 - yDistance >= 0 &&
                                frequency.Value[i].Item2 + xDistance < input[0].Length &&
                                input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 + xDistance] != '#') {
                                input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 + xDistance] = '#';
                                ++result;
                            }
                            if (frequency.Value[j].Item2 - xDistance > 0 &&
                                frequency.Value[j].Item1 + yDistance < input.Count &&
                                input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 - xDistance] != '#') {
                                input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 - xDistance] = '#';
                                ++result;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadCharGrid(filePath);

        Dictionary<char, List<Tuple<int, int>>> frequencies = new Dictionary<char, List<Tuple<int, int>>>();
        for (int y = 0; y < input.Count; y++) {
            for (int x = 0; x < input[y].Length; x++) {
                if (input[y][x] != '.') {
                    if (!frequencies.ContainsKey(input[y][x])) {
                        frequencies.Add(input[y][x], new List<Tuple<int, int>>());
                    }

                    frequencies[input[y][x]].Add(new Tuple<int, int>(y, x));
                }
            }
        }

        foreach (var frequency in frequencies)
        {
            for (int i = 0; i < frequency.Value.Count; ++i) {
                for (int j = 0; j < frequency.Value.Count; ++j) {
                    if (i == j) {
                        continue;
                    }

                    if (input[frequency.Value[i].Item1][frequency.Value[i].Item2] != '#') {
                        input[frequency.Value[i].Item1][frequency.Value[i].Item2] = '#';
                        ++result;
                    }
                    if (input[frequency.Value[j].Item1][frequency.Value[j].Item2] != '#') {
                        input[frequency.Value[j].Item1][frequency.Value[j].Item2] = '#';
                        ++result;
                    }

                    int xDistance = Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);
                    int yDistance = Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                    bool iTrue = true, jTrue = true;
                    if (frequency.Value[i].Item2 <= frequency.Value[j].Item2) { // i left
                        if (frequency.Value[i].Item1 >= frequency.Value[j].Item1) { // i down
                            while (iTrue || jTrue) {
                                if (frequency.Value[i].Item1 + yDistance < input.Count &&
                                    frequency.Value[i].Item2 - xDistance >= 0 &&
                                    input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 - xDistance] != '#') {
                                    input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 - xDistance] = '#';
                                    ++result;
                                }
                                if (frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                    frequency.Value[j].Item1 - yDistance >= 0 &&
                                    input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 + xDistance] != '#') {
                                    input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 + xDistance] = '#';
                                    ++result;
                                }

                                if (!(frequency.Value[i].Item1 + yDistance < input.Count &&
                                    frequency.Value[i].Item2 - xDistance >= 0)) {
                                    iTrue = false;
                                }
                                if (!(frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                    frequency.Value[j].Item1 - yDistance >= 0)) {
                                    jTrue = false;
                                }

                                xDistance += Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);;
                                yDistance += Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                            }
                        } else {  // i up
                            while (iTrue || jTrue) {
                                if (frequency.Value[i].Item1 - yDistance >= 0 &&
                                    frequency.Value[i].Item2 - xDistance >= 0 &&
                                    input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 - xDistance] != '#') {
                                    input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 - xDistance] = '#';
                                    ++result;
                                }
                                if (frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                    frequency.Value[j].Item1 + yDistance < input.Count &&
                                    input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 + xDistance] != '#') {
                                    input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 + xDistance] = '#';
                                    ++result;
                                }

                                if (!(frequency.Value[i].Item1 - yDistance >= 0 &&
                                    frequency.Value[i].Item2 - xDistance >= 0)) {
                                    iTrue = false;
                                }
                                if (!(frequency.Value[j].Item2 + xDistance < input[0].Length &&
                                    frequency.Value[j].Item1 + yDistance < input.Count)) {
                                    jTrue = false;
                                }

                                xDistance += Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);;
                                yDistance += Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                            }
                        }
                    } else { // i right
                        if (frequency.Value[i].Item1 >= frequency.Value[j].Item1) { // i down
                            while (iTrue || jTrue) {
                                if (frequency.Value[i].Item1 + yDistance < input.Count &&
                                    frequency.Value[i].Item2 + xDistance < input[0].Length &&
                                    input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 + xDistance] != '#') {
                                    input[frequency.Value[i].Item1 + yDistance][frequency.Value[i].Item2 + xDistance] = '#';
                                    ++result;
                                }
                                if (frequency.Value[j].Item2 - xDistance >= 0 &&
                                    frequency.Value[j].Item1 - yDistance >= 0 &&
                                    input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 - xDistance] != '#') {
                                    input[frequency.Value[j].Item1 - yDistance][frequency.Value[j].Item2 - xDistance] = '#';
                                    ++result;
                                }

                                if (!(frequency.Value[i].Item1 + yDistance < input.Count &&
                                    frequency.Value[i].Item2 + xDistance < input[0].Length)) {
                                    iTrue = false;
                                }
                                if (!(frequency.Value[j].Item2 - xDistance >= 0 &&
                                    frequency.Value[j].Item1 - yDistance >= 0)) {
                                    jTrue = false;
                                }

                                xDistance += Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);;
                                yDistance += Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                            }
                        } else {  // i up
                            while (iTrue || jTrue) {
                                if (frequency.Value[i].Item1 - yDistance >= 0 &&
                                    frequency.Value[i].Item2 + xDistance < input[0].Length &&
                                    input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 + xDistance] != '#') {
                                    input[frequency.Value[i].Item1 - yDistance][frequency.Value[i].Item2 + xDistance] = '#';
                                    ++result;
                                }
                                if (frequency.Value[j].Item2 - xDistance > 0 &&
                                    frequency.Value[j].Item1 + yDistance < input.Count &&
                                    input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 - xDistance] != '#') {
                                    input[frequency.Value[j].Item1 + yDistance][frequency.Value[j].Item2 - xDistance] = '#';
                                    ++result;
                                }

                                if (!(frequency.Value[i].Item1 - yDistance >= 0 &&
                                    frequency.Value[i].Item2 + xDistance < input[0].Length)) {
                                    iTrue = false;
                                }
                                if (!(frequency.Value[j].Item2 - xDistance > 0 &&
                                    frequency.Value[j].Item1 + yDistance < input.Count)) {
                                    jTrue = false;
                                }

                                xDistance += Math.Abs(frequency.Value[i].Item2 - frequency.Value[j].Item2);;
                                yDistance += Math.Abs(frequency.Value[i].Item1 - frequency.Value[j].Item1);
                            }
                        }
                    }
                }
            }
        }

        // IAlgorithms.PrintCharGrid(input);

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day8Star1Example1.txt");

        Star1Algorithm("../../../Input/Day8Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day8Star1Example1.txt");

        Star2Algorithm("../../../Input/Day8Star1.txt");
    }
}