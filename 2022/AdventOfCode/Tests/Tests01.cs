using AdventOfCode;

namespace Tests;

public class Test01 {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day1Part1_Example()
    {
        var input = Input.Day1Example;

        var Day1 = new Day1();
        var lists = Day1.Parse(input);

        var result = Day1.Day1Part1(lists);
        result.Should().Be(24000);
    }

    [Test]
    public void Day1Part1()
    {
        var input = Input.Day1Input;

        var Day1 = new Day1();
        var lists = Day1.Parse(input);

        var result = Day1.Day1Part1(lists);
        result.Should().Be(66616);
    }

    [Test]
    public void Day1Part2_Example()
    {
        var input = Input.Day1Input;

        var Day1 = new Day1();
        var lists = Day1.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(45000);
    }

    [Test]
    public void Day1Part2()
    {
        var input = Input.Day1Input;

        var Day1 = new Day1();
        var lists = Day1.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(45000);
    }

}