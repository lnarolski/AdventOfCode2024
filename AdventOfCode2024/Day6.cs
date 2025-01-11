class Day6 : IAlgorithms, IStars
{
    public Day6()
    {
        Star1();
        Star2();
    }

    class Guard {
        public enum Direction
        {
            up = 0,
            right = 1,
            down = 2,
            left = 3
        }

        public Guard(List<char[]> map) {
            for (int y = 0; y < map.Count; ++y)
            {
                for (int x = 0; x < map[y].Length; ++x)
                {
                    if (map[y][x] == '^') {
                        this.x = x;
                        this.y = y;
                        startingX = x;
                        startingY = y;
                        direction = Direction.up;
                    }
                }
            }
        }

        public bool Step(List<char[]> map) {
            if (y < 0 || y >= map.Count ||
                x < 0 || x >= map[0].Length) {
                return false;
            }

            if (map[y][x] != 'X') {
                map[y][x] = 'X';
                distinctPostitions++;
            }

            switch (direction) {
                case Direction.up:
                    if (y - 1 < 0) {
                        y -= 1;
                        return true;
                    } else if (map[y - 1][x] == '#') {
                        direction++;
                    } else {
                        y -= 1;
                    }
                    return true;
                case Direction.right:
                    if (x + 1 >= map[y].Length) {
                        x += 1;
                        return true;
                    } else if (map[y][x + 1] == '#') {
                        direction++;
                    } else {
                        x += 1;
                    }
                    return true;
                case Direction.down:
                    if (y + 1 >= map.Count) {
                        y += 1;
                        return true;
                    } else if (map[y + 1][x] == '#') {
                        direction++;
                    } else {
                        y += 1;
                    }
                    return true;
                case Direction.left:
                    if (x - 1 < 0) {
                        x -= 1;
                        return true;
                    } else if (map[y][x - 1] == '#') {
                        direction = Direction.up;
                    } else {
                        x -= 1;
                    }
                    return true;
            }

            return true;
        }

        public bool StepStar2(List<char[]> map) {
            if (y < 0 || y >= map.Count ||
                x < 0 || x >= map[0].Length) {
                return false;
            }

            if (map[y][x] != 'X') {
                map[y][x] = 'X';

                if (!(y == startingY && x == startingX)) {
                    visitedPositions.Add(new Tuple<int, int>(y, x));
                }
            }

            switch (direction) {
                case Direction.up:
                    if (y - 1 < 0) {
                        y -= 1;
                        return true;
                    } else if (map[y - 1][x] == '#') {
                        direction++;
                    } else {
                        y -= 1;
                    }
                    return true;
                case Direction.right:
                    if (x + 1 >= map[y].Length) {
                        x += 1;
                        return true;
                    } else if (map[y][x + 1] == '#') {
                        direction++;
                    } else {
                        x += 1;
                    }
                    return true;
                case Direction.down:
                    if (y + 1 >= map.Count) {
                        y += 1;
                        return true;
                    } else if (map[y + 1][x] == '#') {
                        direction++;
                    } else {
                        y += 1;
                    }
                    return true;
                case Direction.left:
                    if (x - 1 < 0) {
                        x -= 1;
                        return true;
                    } else if (map[y][x - 1] == '#') {
                        direction = Direction.up;
                    } else {
                        x -= 1;
                    }
                    return true;
            }

            return true;
        }

        public bool FindLoop(List<char[]> map) {
            if (y < 0 || y >= map.Count ||
                x < 0 || x >= map[0].Length) {
                return false;
            }

            switch (direction) {
                case Direction.up:
                    if (y - 1 < 0) {
                        y -= 1;
                        return true;
                    } else if (map[y - 1][x] == '#' || map[y - 1][x] == 'O') {
                        direction++;
                    } else {
                        y -= 1;
                    }
                    break;
                case Direction.right:
                    if (x + 1 >= map[y].Length) {
                        x += 1;
                        return true;
                    } else if (map[y][x + 1] == '#' || map[y][x + 1] == 'O') {
                        direction++;
                    } else {
                        x += 1;
                    }
                    break;
                case Direction.down:
                    if (y + 1 >= map.Count) {
                        y += 1;
                        return true;
                    } else if (map[y + 1][x] == '#' || map[y + 1][x] == 'O') {
                        direction++;
                    } else {
                        y += 1;
                    }
                    break;
                case Direction.left:
                    if (x - 1 < 0) {
                        x -= 1;
                        return true;
                    } else if (map[y][x - 1] == '#' || map[y][x - 1] == 'O') {
                        direction = Direction.up;
                    } else {
                        x -= 1;
                    }
                    break;
            }

            return true;
        }

        public int x = 0;
        public int y = 0;

        public int startingX = 0;
        public int startingY = 0;
        public Direction direction = Direction.up;
        public long distinctPostitions = 0;
        public List<Tuple<int, int>> visitedPositions = new List<Tuple<int, int>>();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var map = IAlgorithms.LoadCharGrid(filePath);

        Guard guard = new Guard(map);
        while (guard.Step(map));

        // IAlgorithms.PrintCharGrid(map);

        Console.WriteLine($"Star 1: {guard.distinctPostitions}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        var map = IAlgorithms.LoadCharGrid(filePath);

        Guard guardFast = new Guard(map);
        while (guardFast.StepStar2(map));

        Guard guardSlow = new Guard(map);
        guardSlow.x = guardFast.startingX;
        guardSlow.y = guardFast.startingY;
        guardSlow.startingX = guardFast.startingX;
        guardSlow.startingY = guardFast.startingY;

        // guardFast.visitedPositions.Add(new Tuple<int, int>(6,3));

        foreach (var visitedPosition in guardFast.visitedPositions)
        {
            guardFast.x = guardFast.startingX;
            guardFast.y = guardFast.startingY;
            guardFast.direction = Guard.Direction.up;

            guardSlow.x = guardSlow.startingX;
            guardSlow.y = guardSlow.startingY;
            guardSlow.direction = Guard.Direction.up;

            map[visitedPosition.Item1][visitedPosition.Item2] = 'O';

            bool workingFast = true, workingSlow = true;
            UInt64 i = 0;
            while (workingFast && workingSlow) {
                workingFast = guardFast.FindLoop(map);
                if (i % 2 == 1) {
                    workingSlow = guardSlow.FindLoop(map);
                }

                if (guardFast.x == guardSlow.x &&
                    guardFast.y == guardSlow.y &&
                    guardFast.direction == guardSlow.direction) {
                    result++;

                    // IAlgorithms.PrintCharGrid(map);
                    // Console.WriteLine();
                    // Console.WriteLine($"y: {visitedPosition.Item1}, x: {visitedPosition.Item2}");

                    break;
                }

                ++i;
            }

            map[visitedPosition.Item1][visitedPosition.Item2] = 'X';
        }

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day6Star1Example1.txt");

        Star1Algorithm("../../../Input/Day6Star1.txt");
    }

    public void Star2()
    {
        // Star2Algorithm("../../../Examples/Day6Star1Example1.txt");

        Star2Algorithm("../../../Input/Day6Star1.txt");
    }
}