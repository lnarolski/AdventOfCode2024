
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

        string stringToFind = "XMAS";

        // HORIZONTAL
        int forwardIndex = 0, backwardIndex = stringToFind.Length - 1;
        for (int y = 0; y < input.Count; y++)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y][x] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y][x] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y][x] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
        }
        //

        // VERTICAL
        for (int x = 0; x < input[0].Length; x++)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int y = 0; y < input.Count; y++)
            {
                if (input[y][x] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y][x] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y][x] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y][x] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
        }
        //

        // DIAGONAL
        for (int y = input.Count - 1; y > 0; y--)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int x = 0; x < input[0].Length && y + x < input.Count; x++)
            {
                if (input[y + x][x] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y + x][x] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y + x][x] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y + x][x] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
        }

        for (int x = 0; x < input[0].Length; x++)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int y = 0; y < input.Count && y + x < input[0].Length; y++)
            {
                if (input[y][x + y] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y][x + y] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y][x + y] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y][x + y] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
        }
        //

        // DIAGONAL BACKWARD
        for (int y = input.Count - 1; y > 0; y--)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int x = input[0].Length - 1; x > 0 && y + (input[0].Length - 1 - x) < input.Count; x--)
            {
                if (input[y + (input[0].Length - 1 - x)][x] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y + (input[0].Length - 1 - x)][x] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y + (input[0].Length - 1 - x)][x] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y + (input[0].Length - 1 - x)][x] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
        }

        for (int x = input[0].Length - 1; x > 0; x--)
        {
            forwardIndex = 0;
            backwardIndex = stringToFind.Length - 1;
            for (int y = 0; y < input.Count && x - y > 0; y++)
            {
                if (input[y][x - y] == stringToFind[forwardIndex])
                {
                    forwardIndex++;

                    if (forwardIndex == stringToFind.Length)
                    {
                        result++;
                        forwardIndex = 0;
                    }
                }
                else
                {
                    forwardIndex = 0;

                    if (input[y][x - y] == stringToFind[forwardIndex])
                    {
                        forwardIndex++;
                    }
                }

                if (input[y][x - y] == stringToFind[backwardIndex])
                {
                    backwardIndex--;

                    if (backwardIndex == -1)
                    {
                        result++;
                        backwardIndex = stringToFind.Length - 1;
                    }
                }
                else
                {
                    backwardIndex = stringToFind.Length - 1;

                    if (input[y][x - y] == stringToFind[backwardIndex])
                    {
                        backwardIndex--;
                    }
                }
            }
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
        Star1Algorithm("../../../Examples/Day4Star1Example3.txt");
        // Star1Algorithm("../../../Examples/Day4Star1Example4.txt");

        // Star1Algorithm("../../../Input/Day4Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day4Star2Example1.txt");

        Star2Algorithm("../../../Input/Day4Star1.txt");
    }
}