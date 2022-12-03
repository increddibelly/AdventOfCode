using AdventOfCode;

namespace Tests
{
    public class Tests03
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day03Part1_Example()
        {
            var input = Input.Day03Example;

            var Day03 = new Day03();

            var result = Day03.Day03Part1(input);
            result.Should().Be(157);
        }

        [Test]
        public void Day03Part1()
        {
            var input = Input.Day03Input;

            var Day03 = new Day03();

            var result = Day03.Day03Part1(input);
            result.Should().Be(7785); // < 7862
        }

        [Test]
        public void Day03Part2_Example()
        {
            var input = Input.Day03Example;

            var Day03 = new Day03();

            var result = Day03.Day03Part2(input);
            result.Should().Be(70);
        }

        [Test]
        public void Day03Part2()
        {
            var input = Input.Day03Input;

            var Day03 = new Day03();

            var result = Day03.Day03Part2(input);
            result.Should().Be(2633);
        }
    }
}