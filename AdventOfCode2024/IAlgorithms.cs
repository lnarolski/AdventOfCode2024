public interface IAlgorithms
{
    public void Star1Algorithm(string filePath);
    public void Star2Algorithm(string filePath);

    public static List<List<long>> LoadMatrix(string filePath) {
        var matrix = new List<List<long>>();

        var file = File.OpenText(filePath);
        var line = file.ReadLine();
        while (line != null)
        {
            var columns = new List<long>();
            foreach (var level in line.Split(' ')) {
                columns.Add(Convert.ToInt64(level));
            }
            matrix.Add(columns);
            
            line = file.ReadLine();
        }

        return matrix;
    }

    public static List<string> LoadLines(string filePath) {
        var lines = new List<string>();

        var file = File.OpenText(filePath);
        var line = file.ReadLine();
        while (line != null)
        {
            lines.Add(line);
            
            line = file.ReadLine();
        }

        return lines;
    }
}