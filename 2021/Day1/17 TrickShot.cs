using System.Drawing;

namespace Puzzles;
public class TrickShot
{
    private Rectangle TargetArea;

    private Probe Probe;
    
    private Dictionary<Point, int> Scores = new Dictionary<Point, int>();

    public TrickShot(string input)
    {
        // target area: x = 20..30, y = -10..-5
        var data = input.Trim().Replace("target area: x = ", "")
            .Replace("..", ",")
            .Replace(" y = ", "")
            .Split(",")
            .Select(p => int.Parse(p))
            .ToArray();
        var x1 = data[0];
        var x2 = data[1];
        var y1 = data[3]; // wrong order!
        var y2 = data[2];

        TargetArea = new Rectangle(x1, y1, x2-x1, y2-y1);
        Probe = new Probe(0, 0);
    }

    public bool InTargetArea()
    {
        return TargetArea.Contains(Probe.Location.X, Probe.Location.Y);
    }

    public bool Overshot()
    {
        if (Probe.Speed.X == 0 &&
           (Probe.Location.X > TargetArea.Right || Probe.Location.X < TargetArea.Left))
            return true;

        if (Probe.Location.Y < TargetArea.Bottom &&
           (Probe.Location.X > TargetArea.Right || Probe.Location.X < TargetArea.Left)) 
        {
            return true;
        }

        return false;
    }

    public int BruteForce(int x = 10, int y = 0)
    {
        var throughs = new List<Point>();
        const int undershot = -1;
        const int overshot = -2;
        const int fellthrough = -3;

        var leftX = 0;
        var leftY = 0;
        var rightX = 0;
        var rightY = 0;

        var score = 0;

        score = Shoot(x, y);
        while(score != overshot)
        {
            if (score == fellthrough)
                throughs.Add(new Point(x, y));
            // shoot harder until we overshoot.
            x++;
            score = Shoot(x, y);
        }
        rightX = x;

        do
        {
            x--;
            score = Shoot(x, y);
            if (score == fellthrough)
                throughs.Add(new Point(x, y));
            
            if (score == overshot)
                rightX = x;
        } while (score != undershot);
        leftX = x;

        // find vertical limits
        for(x = leftX; x <= rightX && leftY > -1000 && rightY < 1000; x++)
        {
            while (score != overshot && y < 1000)
            {
                // shoot harder until we overshoot.
                y++;
                score = Shoot(x, y);
                if (score == fellthrough)
                    throughs.Add(new Point(x, y));
            }
            if (score == overshot)
                rightY = y; // should be a dictionary for each x.

            do
            {
                y--;
                score = Shoot(x, y);
                if (score == fellthrough)
                    throughs.Add(new Point(x, y));
                if (score == overshot)
                    rightY = y;
            } while (score != undershot && y >= -1000);
            if (score == undershot)
            {
                leftY = y;
            }
        }

        for (y = leftY; y <= rightY; y++)
        {
            for(x = leftX; x <= rightX; x++)
            {
                score = Shoot(x, y);
            }
        }

        return Scores.Values.Max();
    }

    public int Shoot(int x, int y)
    {
        var key = new Point(x, y);
        if (Scores.ContainsKey(key))
            return Scores[key];

        int height = 0;
        
        Probe.Speed.X = x;
        Probe.Speed.Y = y;

        do
        {
            Probe.Move();
            if (Probe.Location.Y > height)
            {
                height = Probe.Location.Y;
            }

            
            if (Probe.Location.Y < TargetArea.Bottom &&
                Probe.Location.X < TargetArea.Left)
            {
                Scores[key] = -1;
                break; // undershot left side
            }
            if (Probe.Location.Y < TargetArea.Top &&
                Probe.Location.X > TargetArea.Right)
            {
                Scores[key] = -2;
                break; // overshot right side
            }            
            if (Probe.Location.Y < TargetArea.Bottom &&
                Probe.Location.X >= TargetArea.Left &&
                Probe.Location.X <= TargetArea.Right)
            {
                Scores[key] = -3;
                break; // fell through
            }

        } while (!InTargetArea());

        if ( InTargetArea())
        {
            Console.WriteLine($"yay! {x},{y} => height = {height}");
            Scores[key] = height;
        }

        return Scores[key];
    }
}

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}

public class Probe
{
    public Vector Location { get; set; }
    public Vector Speed { get; set; }

    public override string ToString()
    {
        return $"{Location.X},{Location.Y} => {Speed.X},{Speed.Y}";
    }

    public Probe(int x, int y)
    {
        Location = new Vector { X = 0, Y = 0 };
        Speed = new Vector { X = x, Y = y };
    }

    public void Move()
    {
        // The probe's x position increases by its x velocity.
        // The probe's y position increases by its y velocity.
        // Due to drag, the probe's x velocity changes by 1 toward the value 0; that is,
        //   decreases by 1 if it is greater than 0,
        //   increases by 1 if it is less than 0,
        //   or does not change if it is already 0.
        // Due to gravity, the probe's y velocity decreases by 1.

        Location.X += Speed.X;
        Location.Y += Speed.Y;
        
        Speed.X = Drag(Speed.X);
        Speed.Y -= 1;
    }

    private static int Drag(int speed)
    {
        if (speed > 0)
        {
            return speed - 1;
        }
        else
        {
            if (speed < 0)
            {
                return speed + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

