using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Map
{
	private List<List<int>> _distanceFromStart = new List<List<int>>();
    private List<List<Pipe>> _pipes = new List<List<Pipe>>();
	
    private Pipe _start { get; set; }
    
	public static Map Parse(string input)
    {
        var map = new Map();
        var lines = input.Split(Environment.NewLine);
        var width = lines[0].Length;
		for(var y =0; y < lines.Length; y++)
        {
            map._pipes.Add(new List<Pipe>());
			map._distanceFromStart.Add(Enumerable.Repeat(-1, width).ToList());
			
            for(var x = 0; x < lines[y].Length; x++)
            {
                var pipe = Pipe.Parse(lines[y][x], x, y);
                if (pipe.IsStart)
                    map._start = pipe;

                map._pipes[y].Add(pipe);
            }
        }
        return map;
    }
  
    private IEnumerable<Pipe> GetAdjacent(Pipe pipe)
    {
        for(var y = pipe.Y -1; y < pipe.Y + 1; y++)
        {
            for (var x = pipe.X -1; x < pipe.X + 1; x++)
			{
				if (y < 0 || x < 0 || y >= _pipes.Count || x >= _pipes[y].Count)
				{
					continue;
				}
				
				if ( x == pipe.X && y == pipe.Y)
					continue;
				
				yield return _pipes[y][x];
			}
        }
    }

	public int GetDistance(Pipe pipe)
	{
		if (_distances[pipe.Y][pipe.X]
	}

    public int GetDistances()
    {
		var currentPipe = _start;
		do {
			var pipes = GetAdjacent(currentPipe);
			foreach(var pipe in pipes)
			{
				if (currentpipe.ConnectsTo(pipe))
				{
					// they connect, pipe has one step more than currentPipe.
				}
					
			}
		} while (currentPipe != null);
    }
}

public class Pipe
{
    private char _input;
    public bool IsStart { get; private set; }

    public bool GoesUp { get; private set; }
    public bool GoesDown { get; private set; }
    public bool GoesLeft { get; private set; }
    public bool GoesRight { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
	
	public bool ConnectsTo(Pipe other) {
		if (GoesUp    && other.X == X   && other.Y == Y-1) return true;
		if (GoesDown  && other.X == X   && other.Y == Y+1) return true;
		if (GoesLeft  && other.X == X-1 && other.Y == Y) return true;
		if (GoesRight && other.X == X+1 && other.Y == Y) return true;
		return false;
	}

    public static Pipe Parse(char input, int x, int y)
    {
        /*
        | is a vertical pipe connecting north and south.
        - is a horizontal pipe connecting east and west.
        L is a 90-degree bend connecting north and east.
        J is a 90-degree bend connecting north and west.
        7 is a 90-degree bend connecting south and west.
        F is a 90-degree bend connecting south and east.
        . is ground; there is no pipe in this tile.
        S is the starting position of the animal; */

        return new Pipe
        {
            _input = input,
            IsStart = input == 'S',
            GoesLeft = "-J7".Contains(input),
            GoesRight = "LF-".Contains(input),
            GoesUp = "|LJ".Contains(input),
            GoesDown = "|F7".Contains(input),
            X = x,
            Y = y
        };
    }
}
