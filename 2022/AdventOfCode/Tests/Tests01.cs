using AdventOfCode;

namespace Tests;

public class Test01 {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day01Part1_Example()
    {
        var input = Input.Day01Example;

        var Day01 = new Day01();
        var lists = Day01.Parse(input);

        var result = Day01.Day01Part1(lists);
        result.Should().Be(24000);
    }

    [Test]
    public void Day01Part1()
    {
        var input = Input.Day01Input;

        var Day01 = new Day01();
        var lists = Day01.Parse(input);

        var result = Day01.Day01Part1(lists);
        result.Should().Be(66616);
    }

    [Test]
    public void Day01Part2_Example()
    {
        var input = Input.Day01Input;

        var Day01 = new Day01();
        var lists = Day01.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(45000);
    }

    [Test]
    public void Day01Part2()
    {
        var input = Input.Day01Input;

        var Day01 = new Day01();
        var lists = Day01.Parse(input);

        var groups = lists.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).ToArray();
        groups.Sum().Should().Be(45000);
    }

}