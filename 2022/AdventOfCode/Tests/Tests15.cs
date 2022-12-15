using AdventOfCode;

namespace Tests;

public class Tests15
{
    private Day15 day15;

    [SetUp]
    public void Setup()
    {
        day15 = new Day15();
    }

    [Test]
    public void Day15Part1_Example()
    {
        var result = day15.Day15Part1(Input.Day15Example, 10);
        result.Should().Be(26);
    }

    [Test]
    public void Day15Part1()
    {
        var result = day15.Day15Part1(Input.Day15Input, 2000000);
        result.Should().Be(56120);
    }

    [Test]
    public void Day15Part2_Example()
    {
        var result = day15.Day15Part2(Input.Day15Example);
        result.Should().Be(1537);
    }

    [Test]
    public void Day15Part2()
    {
        var result = day15.Day15Part2(Input.Day15Input);
        result.Should().Be(1537);
    }
}