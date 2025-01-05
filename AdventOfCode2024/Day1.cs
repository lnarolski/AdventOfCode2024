class Day1
{
    public Day1() {
        Star1();
        Star2();
    }

    private void Star1Algorithm(string filePath) {
        long totalDistance = 0;

        List<long> leftList = new List<long>();
        List<long> rightList = new List<long>();

        var file = File.OpenText(filePath);
        var line = file.ReadLine();
        while (line != null)
        {
            var array = line.Split("   ");
            leftList.Add(Convert.ToInt64(array[0]));
            rightList.Add(Convert.ToInt64(array[1]));
            
            line = file.ReadLine();
        }

        leftList.Sort();
        rightList.Sort();

        for (int i = 0; i < leftList.Count; ++i) {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine($"Star 1: {totalDistance}");
    }

    private void Star2Algorithm(string filePath) {
        long similarityScore = 0;

        List<long> leftList = new List<long>();
        Dictionary<long, long> rightList = new Dictionary<long, long>();

        var file = File.OpenText(filePath);
        var line = file.ReadLine();
        while (line != null)
        {
            var array = line.Split("   ");
            var leftValue = Convert.ToInt64(array[0]);
            var rightValue = Convert.ToInt64(array[1]);
            
            leftList.Add(leftValue);
            if (rightList.ContainsKey(rightValue)) {
                rightList[rightValue] += 1;
            } else {
                rightList.Add(rightValue, 1);
            }

            line = file.ReadLine();
        }

        foreach (var item in leftList) {
            if (rightList.ContainsKey(item)) {
                similarityScore += item * rightList[item];
            }
        }

        Console.WriteLine($"Star 2: {similarityScore}");
    }

    private void Star1() {
        // Star1Algorithm("../../../Examples/Day1Star1Example1.txt");

        Star1Algorithm("../../../Input/Day1Star1.txt");
    }

    private void Star2() {
        // Star2Algorithm("../../../Examples/Day1Star1Example1.txt");

        Star2Algorithm("../../../Input/Day1Star1.txt");
    }
}