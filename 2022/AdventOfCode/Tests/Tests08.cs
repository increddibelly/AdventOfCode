using AdventOfCode;

namespace Tests;

public class Tests08
{
    [Test]
    public void Day08Part1_Example()
    {
        var Day08 = new Day08();
        var items = Day08.Parse(Input.Day08Example);

        var result = Day08.Day08Part1(items);
        result.Should().Be(21);
    }

    [Test]
    public void Day08Part1()
    {
        var Day08 = new Day08();
        var items = Day08.Parse(Input.Day08Input);

        var result = Day08.Day08Part1(items);
        result.Should().Be(1859);
    }

    [Test]
    public void Day08Part2_Example()
    {
        var Day08 = new Day08();
        var items = Day08.Parse(Input.Day08Example);

        var result = Day08.Day08Part2(items);
        result.Should().Be(8);
    }

    [Test]
    public void Day08Part2()
    {
        var Day08 = new Day08();
        var items = Day08.Parse(Input.Day08Input);

        var result = Day08.Day08Part2(items);
        result.Should().Be(332640); //too high
    }
}