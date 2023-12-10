

public class Map
{
    private List<List<Pipe>> _pipes = new List<List<Pipe>>();
    private Pipe _start { get; set; }
    public static Map Parse(string input)
    {
        var map = new Map();
        var lines = input.Split(Environment.NewLine);
        for(var y =0; y < lines.Length; y++)
        {
            map._pipes.Add(new List<Pipe>());
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

    private Pipe[][] Adjacent(Pipe pipe)
    {
        for(var y = pipe.Y -1; y < pipe.Y + 1; y++)
        {
            for (var x = pipe.X -1; x < pipe.X + 1; x++)

        }
    }


    public int DistanceFrom(Pipe pipe)
    {

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

        Pipe pipe = new Pipe
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
