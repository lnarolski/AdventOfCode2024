
using System.Text.RegularExpressions;

class Day4 : IAlgorithms, IStars
{
    public Day4() {
        Star1();
        // Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);

        string stringToFind = "XMAS";
        int forwardIndex = 0, backwardIndex = stringToFind.Length - 1;
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == stringToFind[forwardIndex]) {
                    if (forwardIndex == stringToFind.Length - 1) {
                        result++;
                        forwardIndex = 0;
                    } else {
                        forwardIndex++;
                    }
                } else {
                    forwardIndex = 0;
                }

                if (input[y][x] == stringToFind[backwardIndex]) {
                    if (backwardIndex == 0) {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    } else {
                        backwardIndex--;
                    }
                } else {
                    backwardIndex = stringToFind.Length - 1;
                }
            }
        }

        forwardIndex = 0;
        backwardIndex = stringToFind.Length - 1;
        for (int x = 0; x < input[0].Length; x++)
        {
            for (int y = 0; y < input.Count; y++)
            {
                if (input[y][x] == stringToFind[forwardIndex]) {
                    if (forwardIndex == stringToFind.Length - 1) {
                        result++;
                        forwardIndex = 0;
                    } else {
                        forwardIndex++;
                    }
                } else {
                    forwardIndex = 0;
                }

                if (input[y][x] == stringToFind[backwardIndex]) {
                    if (backwardIndex == 0) {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    } else {
                        backwardIndex--;
                    }
                } else {
                    backwardIndex = stringToFind.Length - 1;
                }
            }
        }

        forwardIndex = 0;
        backwardIndex = stringToFind.Length - 1;
        for (int y = input.Count - stringToFind.Length; y > 0; y--)
        {
            for (int x = 0; x < input[0].Length && y + x < input.Count; x++)
            {
                if (input[y + x][x] == stringToFind[forwardIndex]) {
                    if (forwardIndex == stringToFind.Length - 1) {
                        result++;
                        forwardIndex = 0;
                    } else {
                        forwardIndex++;
                    }
                } else {
                    forwardIndex = 0;
                }

                if (input[y + x][x] == stringToFind[backwardIndex]) {
                    if (backwardIndex == 0) {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    } else {
                        backwardIndex--;
                    }
                } else {
                    backwardIndex = stringToFind.Length - 1;
                }
            }
        }

        forwardIndex = 0;
        backwardIndex = stringToFind.Length - 1;
        for (int x = 1; x < input[0].Length - stringToFind.Length + 1; x++)
        {
            for (int y = 0; y < input.Count && y + x < input[0].Length; y++)
            {
                if (input[y][x + y] == stringToFind[forwardIndex]) {
                    if (forwardIndex == stringToFind.Length - 1) {
                        result++;
                        forwardIndex = 0;
                    } else {
                        forwardIndex++;
                    }
                } else {
                    forwardIndex = 0;
                }

                if (input[y][x + y] == stringToFind[backwardIndex]) {
                    if (backwardIndex == 0) {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    } else {
                        backwardIndex--;
                    }
                } else {
                    backwardIndex = stringToFind.Length - 1;
                }
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1() {
        Star1Algorithm("../../../Examples/Day4Star1Example1.txt");

        // Star1Algorithm("../../../Input/Day4Star1.txt");
    }

    public void Star2() {
        // Star2Algorithm("../../../Examples/Day4Star2Example1.txt");

        Star2Algorithm("../../../Input/Day4Star1.txt");
    }
}