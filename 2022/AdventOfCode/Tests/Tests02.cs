using AdventOfCode;

namespace Tests
{
    public class Tests02
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day2Part1_Example()
        {
            var input = Input.Day2Example;

            var Day2 = new Day2();
            var games = Day2.Parse(input);

            var result = Day2.Day2Part1(games);
            result.Should().Be(15);
        }

        [Test]
        public void Day2Part1()
        {
            var input = Input.Day2Input;

            var Day2 = new Day2();
            var games = Day2.Parse(input);

            var result = Day2.Day2Part1(games);
            result.Should().Be(15);
        }

        [Test]
        public void Day2Part2_Example()
        {
            var input = Input.Day2Example;

            var Day2 = new Day2();
            var games = Day2.Parse(input);

            var result = Day2.Day2Part2(games);
            result.Should().Be(12);
        }

        [Test]
        public void Day2Part2()
        {
            var input = Input.Day2Input;

            var Day2 = new Day2();
            var games = Day2.Parse(input);

            var result = Day2.Day2Part2(games);
            result.Should().Be(13433); // < 13937
        }
    }
}