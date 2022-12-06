using AdventOfCode;

namespace Tests;

public class Tests07
{
    public void Day07Part1_Example()
    {
        var Day07 = new Day07();
        var items = Day07.Parse(Input.Day07Example);

        var result = Day07.Day07Part1(items);
        result.Should().Be(1337);
    }

    //[Test]
    //public void Day07Part1()
    //{
    //    var Day07 = new Day07();
    //    var items = Day07.Parse(Input.Day07Input);

    //    var result = Day07.Day07Part1(items);
    //    result.Should().Be(1337);
    //}


    //public void Day07Part1_Example()
    //{
    //    var Day07 = new Day07();
    //    var items = Day07.Parse(Input.Day7Example);

    //    var result = Day07.Day07Part2(items);
    //    result.Should().Be(1337);
    //}

    //[Test]
    //public void Day07Part1()
    //{
    //    var Day07 = new Day07();
    //    var items = Day07.Parse(Input.Day07Input);

    //    var result = Day07.Day07Part2(items);
    //    result.Should().Be(1337);
    //}
}