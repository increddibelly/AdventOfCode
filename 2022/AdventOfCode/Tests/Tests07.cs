using AdventOfCode;

namespace Tests;

public class Tests07
{
    [Test]
    public void Day07Part1_Example()
    {
        var Day07 = new Day07();
        Day07.Parse(Input.Day07Example);

        var result = Day07.Day07Part1();
        result.Should().Be(95437);
    }

    [Test]
    public void Day07Part1()
    {
        var Day07 = new Day07();
        Day07.Parse(Input.Day07Input);

        var result = Day07.Day07Part1();
        result.Should().Be(1770595);
    }

    [Test]
    public void Day07Part2_Example()
    {
        var Day07 = new Day07();
        Day07.Parse(Input.Day07Example);

        var result = Day07.Day07Part2();
        result.Should().Be(24933642);
    }

    [Test]
    public void Day07Part2()
    {
        var Day07 = new Day07();
        Day07.Parse(Input.Day07Input);

        var result = Day07.Day07Part2();
        result.Should().Be(2195372);
    }
}