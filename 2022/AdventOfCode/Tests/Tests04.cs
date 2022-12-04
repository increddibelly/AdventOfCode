using AdventOfCode;

namespace Tests
{
    public class Tests04
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day04Part1_Example()
        {
            var input = Input.Day04Example;

            var Day04 = new Day04();

            var result = Day04.Day04Part1(input);
            result.Should().Be(2);
        }

        [Test]
        public void Day04Part1()
        {
            var input = Input.Day04Input;

            var Day04 = new Day04();

            var result = Day04.Day04Part1(input);
            result.Should().Be(462);
        }

        [Test]
        public void Day04Part2_Example()
        {
            var input = Input.Day04Example;

            var Day04 = new Day04();

            var result = Day04.Day04Part2(input);
            result.Should().Be(4);
        }

        [Test]
        public void Day04Part2()
        {
            var input = Input.Day04Input;

            var Day04 = new Day04();

            var result = Day04.Day04Part2(input);
            result.Should().Be(835);
        }
    }
}