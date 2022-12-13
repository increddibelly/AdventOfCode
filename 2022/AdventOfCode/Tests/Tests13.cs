using AdventOfCode;

namespace Tests;

public class Tests13
{
    private Day13 day13;

    [SetUp]
    public void Setup()
    {
        day13 = new Day13();
    }

    [Test]
    public void Day13Part1_Example()
    {
        var result = day13.Day13Part1(Input.Day13Example);
        result.Should().Be(13);
    }

    [Test]
    public void Day13Part1()
    {
        var result = day13.Day13Part1(Input.Day13Input);
        result.Should().Be(6394);
    }

    [Test]
    public void Day13Part2_Example()
    {
        var result = day13.Day13Part2(Input.Day13Example);
        result.Should().Be(1337);
    }

    [Test]
    public void Day13Part2()
    {
        var result = day13.Day13Part2(Input.Day13Input);
        result.Should().Be(1337);
    }
}