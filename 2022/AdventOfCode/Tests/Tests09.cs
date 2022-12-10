using AdventOfCode;

namespace Tests;

public class Tests09
{
    [Test]
    public void Day09Part1_Example()
    {
        var Day09 = new Day09();
        var items = Day09.Parse(Input.Day09Example);

        var result = Day09.Day09Part1(items);
        result.Should().Be(13);
    }

    [Test]
    public void Day09Part1()
    {
        var Day09 = new Day09();
        var items = Day09.Parse(Input.Day09Input);

        var result = Day09.Day09Part1(items);
        result.Should().Be(6256);
    }


    public void Day09Part2_Example()
    {
        var Day09 = new Day09();
        var items = Day09.Parse(Input.Day09Example);

        var result = Day09.Day09Part2(items);
        result.Should().Be(1337);
    }

    [Test]
    public void Day09Part2()
    {
        var Day09 = new Day09();
        var items = Day09.Parse(Input.Day09Input);

        var result = Day09.Day09Part2(items);
        result.Should().Be(1337);
    }
}