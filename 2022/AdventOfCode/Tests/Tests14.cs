using AdventOfCode;

namespace Tests;

public class Tests14
{
    private Day14 day14;

    [SetUp]
    public void Setup()
    {
        day14 = new Day14();
    }

    [Test]
    public void Day14Part1_Example()
    {
        var result = day14.Day14Part1(Input.Day14Example);
        result.Should().Be(10605);
    }

    [Test]
    public void Day14Part1()
    {
        var result = day14.Day14Part1(Input.Day14Input);
        result.Should().Be(56120);
    }

    [Test]
    public void Day14Part2_Example()
    {
        var result = day14.Day14Part2(Input.Day14Example);
        result.Should().Be(1437);
    }

    [Test]
    public void Day14Part2()
    {
        var result = day14.Day14Part2(Input.Day14Input);
        result.Should().Be(1437);
    }
}