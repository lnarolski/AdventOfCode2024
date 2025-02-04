
class Day2 : IAlgorithms, IStars
{
    public Day2() {
        Star1();
        Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        var reports = IAlgorithms.LoadMatrix(filePath);

        long safeReports = 0;
        foreach (var report in reports) {
            bool safe = true;
            bool ascending = false;
            for (int i = 1; safe && i < report.Count; ++i) {
                if (report[i] == report[i - 1]) {
                    safe = false;
                    break;
                }

                if (i == 1) {
                    ascending = report[1] > report[0];
                } else {
                    if (report[i] > report[i - 1] && !ascending ||
                        report[i] < report[i - 1] && ascending) {
                        safe = false;
                        break;
                    }
                }

                if (Math.Abs(report[i] - report[i - 1]) > 3) {
                        safe = false;
                        break;
                }
            }

            if (safe) {
                safeReports += 1;
            }
        }

        Console.WriteLine($"Star 1: {safeReports}");
    }

    public void Star2Algorithm(string filePath)
    {
        var reports = IAlgorithms.LoadMatrix(filePath);

        long safeReports = 0;
        foreach (var report in reports) {
            bool safe = true;
            bool ascending = false;
            bool warning = false;
            for (int i = 0; i < report.Count - 1; ++i) {
                if (report[i] == report[i + 1]) {
                    safe = false;
                    warning = true;
                    break;
                }

                if (i == 0) {
                    ascending = report[1] > report[0];
                } else {
                    if (report[i] > report[i + 1] && ascending ||
                        report[i] < report[i + 1] && !ascending) {
                        safe = false;
                        warning = true;
                        break;
                    }
                }

                if (Math.Abs(report[i] - report[i + 1]) > 3) {
                    safe = false;
                    warning = true;
                    break;
                }
            }

            for (int indexToRemove = 0; warning && indexToRemove < report.Count; ++indexToRemove)
            {
                bool tempSafe = true;
                var tempReport = new List<long>(report);
                tempReport.RemoveAt(indexToRemove);

                ascending = false;
                for (int i = 0; i < tempReport.Count - 1; ++i) {
                    if (tempReport[i] == tempReport[i + 1]) {
                        tempSafe = false;
                        break;
                    }

                    if (i == 0) {
                        ascending = tempReport[1] > tempReport[0];
                    } else {
                        if (tempReport[i] > tempReport[i + 1] && ascending ||
                            tempReport[i] < tempReport[i + 1] && !ascending) {
                            tempSafe = false;
                            break;
                        }
                    }

                    if (Math.Abs(tempReport[i] - tempReport[i + 1]) > 3) {
                        tempSafe = false;
                        break;
                    }
                }

                if (tempSafe) {
                    safe = true;
                }
            }

            if (safe) {
                safeReports += 1;
            }
        }

        Console.WriteLine($"Star 2: {safeReports}");
    }

    public void Star1() {
        // Star1Algorithm("../../../Examples/Day2Star1Example1.txt");

        Star1Algorithm("../../../Input/Day2Star1.txt");
    }

    public void Star2() {
        // Star2Algorithm("../../../Examples/Day2Star1Example1.txt");

        Star2Algorithm("../../../Input/Day2Star1.txt");
    }
}