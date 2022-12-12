namespace AdventOfCode;

public class Day01
{
    public List<List<int>> Parse(string input)
    {
        var groups = input.Replace(Environment.NewLine + Environment.NewLine, "---");
        groups = groups.Replace(Environment.NewLine, ", ");
        groups = groups.Replace("---", Environment.NewLine);

        var lines = groups.Split(Environment.NewLine);

        var numberList = new List<List<int>>();

        foreach (var line in lines)
        {
            var numbersToParse = line.Split(",");
            var numbers = numbersToParse.Select(n => int.Parse(n));
            numberList.Add(numbers.ToList());
        }
        return numberList;
    }

    public int Day01Part1(List<List<int>> input)
    {
        return input.Select(group => group.Sum()).Max();
    }
}