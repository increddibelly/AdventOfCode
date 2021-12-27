using FluentAssertions;
using NUnit.Framework;
using Puzzles;

namespace AOCTests;
public class Day21Tests
{
    [Test]
    public void Test_Day21_Example()
    {
        // arrange
        var cut = new DiceRoller(new DeterministicDie(), new[] { 4, 8 });

        // act
        var result = cut.Play();

        // assert
        result.Should().Be(739785);
    }

    [Test]
    public void Test_Day21_Puzzle()
    {
        // arrange
        var cut = new DiceRoller(new DeterministicDie(), new[] { 6, 8 });

        // act
        var result = cut.Play();

        // assert
        result.Should().Be(757770);
    }
}
