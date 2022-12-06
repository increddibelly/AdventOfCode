namespace AdventOfCode;

public class Day06
{
    public static string Parse(string input)
    {
        return input;
    }

    public int Day06Part1(string input)
    {
        var items = Parse(input);

        for (var index = 3; index<items.Length; index++)
        {
            var sample = items.Substring(index - 3, 4);
            var grp = sample.GroupBy(x => x)
                .Where(x => x.Count() > 1);
            if (grp.Any()) 
            { 
                continue; 
            }
            return index + 1;
        }
        return -1;
    }

    public int Day06Part2(string input)
    {
        var items = Parse(input);

        for (var index = 13; index < items.Length; index++)
        {
            var sample = items.Substring(index - 13, 14);
            var grp = sample.GroupBy(x => x)
                .Where(x => x.Count() > 1);
            if (grp.Any())
            {
                continue;
            }
            return index + 1;
        }
        return -1;
    }
}
