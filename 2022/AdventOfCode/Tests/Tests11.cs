using AdventOfCode;

namespace Tests;

public class Tests11
{
    [Test]
    public void Day11Part1_Example()
    {
        var Day11 = new Day11();

        var result = Day11.Day11Part1(Input.Day11Example);
        result.Should().Be(10605);
    }

    [Test]
    public void Day11Part1()
    {
        var Day11 = new Day11();

        var result = Day11.Day11Part1(Input.Day11Input);
        result.Should().Be(56120);
    }

    [Test]
    public void Day11Part2_Example()
    {
        var Day11 = new Day11();

        var result = Day11.Day11Part2(Input.Day11Example);
        result.Should().Be(2713310158);
    }

    [Test]
    public void Day11Part2()
    {
        var Day11 = new Day11();

        var result = Day11.Day11Part2(Input.Day11Input);
        result.Should().Be(24389045529);
    }
}