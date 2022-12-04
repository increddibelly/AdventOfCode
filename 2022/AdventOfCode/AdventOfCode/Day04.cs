namespace AdventOfCode;

public class Day04
{
    public static List<ElfRange[]> Parse(string input)
    {
        var result = new List<ElfRange[]>();
        var lines = input.Split(Environment.NewLine);
        foreach(var line in lines)
        {
            var elves = line.Split(",").Select(ParseElfRange).ToArray();
            result.Add(elves);
        }

        return result;
    }

    private static ElfRange ParseElfRange(string input)
    {
        var parts = input.Split("-").ToArray();
        return new ElfRange(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public int Day04Part1(string input)
    {
        var elves = Parse(input);
        var overlaps = elves.Where(e => e[0].Overlaps(e[1])).ToArray();
        return overlaps.Length;
    }

    public int Day04Part2(string input)
    {
        var elves = Parse(input);
        var overlaps = elves.Where(e => e[0].PartiallyOverlaps(e[1])).ToArray();
        return overlaps.Length;
    }
}

public class ElfRange
{
    public int Start { get; set; }
    public int End { get; set; }
    public ElfRange(int start, int end)
    {
        Start = start;
        End = end;
    }

    public bool PartiallyOverlaps(ElfRange other)
    {
        return this.Start <= other.End &&
            this.End >= other.Start;
    }
    public bool Overlaps(ElfRange other)
    {
        return 
            (this.Start >= other.Start &&
             this.End   <= other.End) ||
            (other.Start >= this.Start &&
             other.End   <= this.End);
    }
}
