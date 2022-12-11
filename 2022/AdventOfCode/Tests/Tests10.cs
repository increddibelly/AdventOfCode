using AdventOfCode;

namespace Tests;

public class Tests10
{
    [Test]
    public void Day10Part1_Example()
    {
        var Day10 = new Day10();
        var items = Day10.Parse(Input.Day10Example);

        var result = Day10.Day10Part1(items);
        result.Should().Be(13140);
    }

    [Test]
    public void Day10Part1()
    {
        var Day10 = new Day10();
        var items = Day10.Parse(Input.Day10Input);

        var result = Day10.Day10Part1(items);
        result.Should().Be(11720);
    }

    [Test]
    public void Day10Part2_Example()
    {
        var Day10 = new Day10();
        var items = Day10.Parse(Input.Day10Example);

        var result = Day10.Day10Part2(items);
        result.Should().Be(
            "##..##..##..##..##..##..##..##..##..##.." + Environment.NewLine + 
            "###...###...###...###...###...###...###." + Environment.NewLine +
            "####....####....####....####....####...." + Environment.NewLine +
            "#####.....#####.....#####.....#####....." + Environment.NewLine +
            "######......######......######......####" + Environment.NewLine +
            "#######.......#######.......#######.....");
    }

    [Test]
    public void Day10Part2()
    {
        var Day10 = new Day10();
        var items = Day10.Parse(Input.Day10Input);

        var result = Day10.Day10Part2(items, " ");
        result.Should().Be(
           @"#### ###   ##  ###  #### ###   ##    ##" + Environment.NewLine +  
            "#    #  # #  # #  # #    #  # #  #    #" + Environment.NewLine + 
            "###  #  # #    #  # ###  #  # #       #" + Environment.NewLine + 
            "#    ###  #    ###  #    ###  #       #" + Environment.NewLine +
            "#    # #  #  # # #  #    #    #  # #  #" + Environment.NewLine +
            "#### #  #  ##  #  # #### #     ##   ## ");
    }
}