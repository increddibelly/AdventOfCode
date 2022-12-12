using AdventOfCode;

namespace Tests;

public class Tests12
{
    [Test]
    public void Day12Part1_Example()
    {
        var Day12 = new Day12();
        var result = Day12.Day12Part1(Input.Day12Example);
        result.Should().Be(31);
    }

    [Test]
    public void Day12Part1()
    {
        var Day12 = new Day12();

        var result = Day12.Day12Part1(Input.Day12Input);
        result.Should().Be(352);
    }

    [Test]
    public void Day12Part2_Example()
    {
    }

    [Test]
    public void Day12Part2()
    {
    }
}