using FluentAssertions;
using NUnit.Framework;
using Puzzles;
using Puzzles.Input;
using System.Linq;

namespace AOCTests;
public class Day17Tests
{
    [Test]
    public void Test_Day17_Example()
    {
        // arrange
        var cut = new TrickShot("target area: x = 20..30, y = -10..-5");

        // act
        var result = cut.Shoot(6,9);

        // assert
        result.Should().Be(45);
    }
}
