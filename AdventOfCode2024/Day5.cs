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

        var input = IAlgorithms.LoadLines(filePath);

        var rules = new Dictionary<long, List<long>>();
        var pageNumbers = new List<List<long>>();

        bool parsingRules = true;
        foreach (var item in input)
        {
            if (item.Equals("")) {
                parsingRules = false;
            } else {
                if (parsingRules) {
                    var temp = item.Split('|');
                    var key = Convert.ToInt64(temp[0]);
                    var value = Convert.ToInt64(temp[1]);

                    if (!rules.ContainsKey(key)) {
                        rules.Add(key, new List<long>());
                    }
                    rules[key].Add(value);
                } else {
                    var temp = item.Split(',');
                    var convertedPageNumbers = new List<long>();
                    foreach (var pageNumber in temp)
                    {
                        convertedPageNumbers.Add(Convert.ToInt64(pageNumber));
                    }
                    pageNumbers.Add(convertedPageNumbers);
                }
            }
        }

        foreach (var item in pageNumbers)
        {
            HashSet<long> pageNumbersSet = new HashSet<long>() {item[0]};
            bool correctOrder = true;

            for (int i = 1; correctOrder && i < item.Count; ++i) {
                if (rules.ContainsKey(item[i])) {
                    foreach (var ruleNumber in rules[item[i]]) {
                        if (pageNumbersSet.Contains(ruleNumber)) {
                            correctOrder = false;
                            break;
                        }
                    }
                }

                if (correctOrder) {
                    pageNumbersSet.Add(item[i]);
                }
            }

            if (correctOrder) {
                result += item[item.Count / 2];
            }
        }

        Console.WriteLine($"Star 1: {result}");
    }

    public void Star2Algorithm(string filePath)
    {
        long result = 0;

        var input = IAlgorithms.LoadLines(filePath);

        var rules = new Dictionary<long, HashSet<long>>();
        var pageNumbers = new List<List<long>>();

        bool parsingRules = true;
        foreach (var item in input)
        {
            if (item.Equals("")) {
                parsingRules = false;
            } else {
                if (parsingRules) {
                    var temp = item.Split('|');
                    var key = Convert.ToInt64(temp[0]);
                    var value = Convert.ToInt64(temp[1]);

                    if (!rules.ContainsKey(key)) {
                        rules.Add(key, new HashSet<long>());
                    }
                    rules[key].Add(value);
                } else {
                    var temp = item.Split(',');
                    var convertedPageNumbers = new List<long>();
                    foreach (var pageNumber in temp)
                    {
                        convertedPageNumbers.Add(Convert.ToInt64(pageNumber));
                    }
                    pageNumbers.Add(convertedPageNumbers);
                }
            }
        }

        foreach (var item in pageNumbers)
        {
            HashSet<long> pageNumbersSet = new HashSet<long>() {item[0]};
            bool correctOrder = true;

            for (int i = 1; correctOrder && i < item.Count; ++i) {
                if (rules.ContainsKey(item[i])) {
                    foreach (var ruleNumber in rules[item[i]]) {
                        if (pageNumbersSet.Contains(ruleNumber)) {
                            correctOrder = false;
                            break;
                        }
                    }
                }

                if (correctOrder) {
                    pageNumbersSet.Add(item[i]);
                }
            }

            if (!correctOrder) {
                LinkedList<long> list = new LinkedList<long>();
                list.AddLast(item[0]);

                for (int j = 1; j < item.Count; ++j) {
                    if (rules.ContainsKey(item[j])) {
                        if (rules[item[j]].Contains(list.First.Value)) {

                        }
                    } else {
                        list.AddLast(item[j]);
                    }
                }

                int i = 0;
                foreach (var el in list)
                {
                    if (i == item.Count / 2) {
                        result += el;
                        break;
                    }

                    ++i;
                }
            }
        }

        Console.WriteLine($"Star 2: {result}");
    }

    public void Star1()
    {
        // Star1Algorithm("../../../Examples/Day5Star1Example1.txt");

        Star1Algorithm("../../../Input/Day5Star1.txt");
    }

    public void Star2()
    {
        Star2Algorithm("../../../Examples/Day5Star1Example1.txt");

        // Star2Algorithm("../../../Input/Day5Star1.txt");
    }
}