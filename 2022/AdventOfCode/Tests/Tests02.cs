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
        public void Day02Part1_Example()
        {
            var input = Input.Day02Example;

            var Day02 = new Day02();
            var games = Day02.Parse(input);

            var result = Day02.Day02Part1(games);
            result.Should().Be(15);
        }

        [Test]
        public void Day02Part1()
        {
            var input = Input.Day02Input;

            var Day02 = new Day02();
            var games = Day02.Parse(input);

            var result = Day02.Day02Part1(games);
            result.Should().Be(13484);
        }

        [Test]
        public void Day02Part2_Example()
        {
            var input = Input.Day02Example;

            var Day02 = new Day02();
            var games = Day02.Parse(input);

            var result = Day02.Day02Part2(games);
            result.Should().Be(12);
        }

        [Test]
        public void Day02Part2()
        {
            var input = Input.Day02Input;

            var Day02 = new Day02();
            var games = Day02.Parse(input);

            var result = Day02.Day02Part2(games);
            result.Should().Be(13433); // < 13937
        }
    }
}