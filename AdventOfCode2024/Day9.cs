class Day9 : IAlgorithms, IStars
{
    public Day9()
    {
        Star1();
        Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);
        LinkedList<List<int>> inputList = new LinkedList<List<int>>();

        int id = 0;
        for (int i = 0; i < input[0].Length; i++)
        {
            if (i % 2 == 0) {
                inputList.AddLast(new List<int>{id % 10, input[0][i] - '0'});
                id++;
            } else {
                inputList.AddLast(new List<int>{-1, input[0][i] - '0'});
            }
        }

        {
        var backward = inputList.Last;
        var forward = inputList.First;
        while (true) {
            if (forward == null) {
                break;
            }

            if (forward.Value[0] != -1 || forward.Value[1] == 0) {
                forward = forward.Next;
                continue;
            }

            while (backward != null && backward.Value[0] == -1) {
                backward = backward.Previous;
            }

            if (backward == null) {
                break;
            }

            if (backward.Value[1] >= forward.Value[1]) {
                forward.Value[0] = backward.Value[0];
                inputList.AddAfter(backward, new LinkedListNode<List<int>>(new List<int>{-1, forward.Value[1]}));
                backward.Value[1] -= forward.Value[1];

                if (backward.Value[1] == 0) {
                    backward.Value[0] = -1;
                }

                forward = forward.Next;
            } else {
                inputList.AddBefore(forward, new LinkedListNode<List<int>>(new List<int>{backward.Value[0], backward.Value[1]}));
                forward.Value[1] -= backward.Value[1];
                backward.Value[0] = -1;
            }
        }
        }

        int position = 0;
        for (var forward = inputList.First; forward != null; forward = forward.Next) {
            if (forward.Value[0] == -1) {
                continue;
            }

            for (int i = 0; i < forward.Value[1]; i++)
            {
                result += position + forward.Value[0];
                position++;
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        Star1Algorithm("../../../Examples/Day9Star1Example1.txt");

        // Star1Algorithm("../../../Input/Day9Star1.txt");
    }

    public void Star2()
    {
        Star2Algorithm("../../../Examples/Day9Star1Example1.txt");

        // Star2Algorithm("../../../Input/Day9Star1.txt");
    }
}