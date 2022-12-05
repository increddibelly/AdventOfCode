using AdventOfCode;

namespace Tests
{
    public class Tests05
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day05Part1_Example()
        {
            var input = Input.Day05Example;

            var Day05 = new Day05();

            var result = Day05.Day05Part1(input);
            result.Should().Be("CMZ");
        }

        [Test]
        public void Day05Part1()
        {
            var input = Input.Day05Input;

            var Day05 = new Day05();

            var result = Day05.Day05Part1(input);
            result.Should().Be("TDCHVHJTG");
        }

        [Test]
        public void Day05Part2_Example()
        {
            var input = Input.Day05Example;

            var Day05 = new Day05();

            var result = Day05.Day05Part2(input);
            result.Should().Be("MCD");
        }

        [Test]
        public void Day05Part2()
        {
            var input = Input.Day05Input;

            var Day05 = new Day05();

            var result = Day05.Day05Part2(input);
            result.Should().Be("NGCMPJLHV");
        }
    }
}