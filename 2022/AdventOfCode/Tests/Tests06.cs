using AdventOfCode;

namespace Tests;

public class Tests06 
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Day06Part1_Example(string input, int expected)
    {
        var Day06 = new Day06();
        var lists = Day06.Parse(input);

        var result = Day06.Day06Part1(lists);
        result.Should().Be(expected);
    }

    [Test]
    public void Day06Part1()
    {
        var input = Input.Day06Input;

        var Day06 = new Day06();

        var result = Day06.Day06Part1(input);
        result.Should().Be(1965);
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Day06Part2_Example(string input, int expected)
    {
        var Day06 = new Day06();

        var result = Day06.Day06Part2(input);
        result.Should().Be(expected);
    }

    [Test]
    public void Day06Part2()
    {
        var input = Input.Day06Input;
        var Day06 = new Day06();

        var result = Day06.Day06Part2(input);
        result.Should().Be(2773);
    }
}