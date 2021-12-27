using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles;
public class DiceRoller
{
    Player[] Players;
    Die _die;

    public DiceRoller(Die die, int[] positions)
    {
        Players = positions.Select(p => new Player { Position = p } ).ToArray();

        Players[0].Position = positions[0];
        Players[1].Position = positions[1];

        _die = die;
    }

    public int Play()
    {
        do
        {
/*
Player 1 rolls 1+2+3 and moves to space 10 for a total score of 10.
Player 2 rolls 4+5+6 and moves to space 3 for a total score of 3.
Player 1 rolls 7+8+9 and moves to space 4 for a total score of 14.
Player 2 rolls 10+11+12 and moves to space 6 for a total score of 9.
Player 1 rolls 13+14+15 and moves to space 6 for a total score of 20.
Player 2 rolls 16+17+18 and moves to space 7 for a total score of 16.
Player 1 rolls 19+20+21 and moves to space 6 for a total score of 26.
Player 2 rolls 22+23+24 and moves to space 6 for a total score of 22.
*/
            for (var p = 0; p < Players.Length; p++)
            {
                for (var i = 0; i < 3; i++)
                {
                    var roll = _die.Roll();
                    Players[p].Step(roll);

                }

                Players[p].GetScore();
                if (Players[p].Score >= 1000)
                {
                    goto WeHaveAWinner;
                }
            }
        } while (Players.All(p => p.Score < 1000));

    WeHaveAWinner:
        return _die.Count * Players.OrderBy(p => p.Score).First().Score;
    }
}

public class Player
{
    public int Position { get; set; }
    public List<int> Steps { get; set; } = new List<int>();
    
    private int score;
    public int Score => score;

    public void Step(int step)
    {
        Steps.Add(step);
        
        Position += step;
        while (Position > 10)
        {
            Position -= 10;
        }
    }
    public void GetScore()
    {
        score += Position;
    }
}

public abstract class Die
{
    public int Count { get; protected set; }
    public virtual int Roll()
    {
        Count++;
        return DoRoll();
    }

    protected abstract int DoRoll();
}

public class DeterministicDie : Die
{
    private int number = 0;

    protected override int DoRoll()
    {
        number = ++number % 101;
        if (number == 0)
            number = 1;

        return number;
    }
}
