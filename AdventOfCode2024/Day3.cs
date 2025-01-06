
using System.Text.RegularExpressions;

class Day3 : IAlgorithms, IStars
{
    public Day3() {
        Star1();
        // Star2();
    }

    public void Star1Algorithm(string filePath)
    {
        long result = 0;

        var programLines = IAlgorithms.LoadLines(filePath);

        foreach (var line in programLines)
        {
            var regexMatches = Regex.Matches(line, @"mul\((\d+,\d+)\)");

            foreach (Match mulInstruction in regexMatches)
            {
                var values = mulInstruction.Groups[1].Value.Split(',');
                result += Convert.ToInt64(values[0]) * Convert.ToInt64(values[1]);
            }
        }

        Console.WriteLine($"Star 1: {result}");
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
        // Star1Algorithm("../../../Examples/Day3Star1Example1.txt");

        Star1Algorithm("../../../Input/Day3Star1.txt");
    }

    public void Star2() {
        // Star2Algorithm("../../../Examples/Day3Star1Example1.txt");

        Star2Algorithm("../../../Input/Day3Star1.txt");
    }
}