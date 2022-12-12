using AdventOfCode;

namespace Tests;

public class Tests12 {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day12Part1_Example()
    {
        var input = Input.Day12Example;

        var Day12 = new Day12();
        var lists = Day12.Parse(input);

        var result = Day12.Day12Part1(lists);
        result.Should().Be(24000);
    }

    [Test]
    public void Day12Part1()
    {
        var input = Input.Day12Input;

        var Day12 = new Day12();
        var lists = Day12.Parse(input);

        var result = Day12.Day12Part1(lists);
        result.Should().Be(66616);
    }

    [Test]
    public void Day12Part2_Example()
    {
        var input = Input.Day12Example;

        var Day12 = new Day12();
        var lists = Day12.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(45000);
    }

    [Test]
    public void Day12Part2()
    {
        var input = Input.Day12Input;

        var Day12 = new Day12();
        var lists = Day12.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(199172);
    }

}