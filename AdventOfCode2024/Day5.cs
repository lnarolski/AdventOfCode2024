class Day5 : IAlgorithms, IStars
{
    public Day5()
    {
        Star1();
        Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day5Star1Example1.txt");

        Star1Algorithm("../../../Input/Day5Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day5Star1Example1.txt");

        Star2Algorithm("../../../Input/Day5Star1.txt");
    }
}