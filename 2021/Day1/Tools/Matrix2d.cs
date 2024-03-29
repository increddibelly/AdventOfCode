﻿using System.Drawing;
using System.Text;

namespace Puzzles.Tools;
public class Matrix2d<T>
{
    protected T[][] Data { get; set; }

    public int Width { get; private set; }
    public int Height { get; private set; }

    public int OffsetX { get; set; } = 0;
    public int OffsetY { get; set; } = 0;

    public Matrix2d(int width, int height, T emptyvalue = default(T)) 
    {
        Width = width;
        Height = height;

        Data = new T[Height][];

        for(var y = 0; y < Height; y++)
        {
            Data[y] = new T[Width];
        }
        
        for(var y=0; y<Height; y++)
        {
            for(var x=0; x<Width; x++)
            {
                this[x,y] = emptyvalue;
            }
        }
    }

    public Matrix2d<T> Subset(int startX, int startY, int endX, int endY)
    {
        var subset = new Matrix2d<T>(endX - startX, endY - startY);
        subset.OffsetX = -startX;
        subset.OffsetY = -startY;
        for (var y = startY; y < endY; y++)
        {
            for (var x = startX; x < endX; x++)
            {
                subset[x, y] = this[x, y];
            }
        }
        subset.OffsetX = 0;
        subset.OffsetY = 0;
        return subset;
    }

    public Matrix2d<T> Copy()
    {
        return Subset(0, 0, Width, Height);
    }

    public void FlipHorizontal()
    {
        var output = new Matrix2d<T>(Width, Height);
        output.OffsetX = OffsetX;
        output.OffsetY = OffsetY;

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                output[x, y] = this[Width - x - 1, y];
            }
        }

        Data = output.Data;
        Width = output.Width;
        Height = output.Height;
    }

    public void FlipVertical()
    {
        var output = new Matrix2d<T>(Width, Height);
        output.OffsetX = OffsetX;
        output.OffsetY = OffsetY;

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                output[x, y] = this[x, Height - y - 1];
            }
        }

        Data = output.Data;
        Width = output.Width;
        Height = output.Height;
    }

    public static Matrix2d<int> ParseInt(string[] input)
    {
        return Parse<int>(input, int.Parse);
    }

    public static Matrix2d<T> Parse<T>(string[] input, Func<string, T> parser)
    {
        var map = new Matrix2d<T>(input[0].Length, input.Length);
        var y = 0;
        foreach (var line in input)
        {
            var x = 0;
            foreach (var i in line)
            {
                map[x++, y] = parser(i.ToString());
            }
            y++;
        }
        Console.WriteLine(map.ToString());
        return map;
    }

    internal IEnumerable<Point> Where(Func<T, bool> predicate)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (predicate(this[x, y]))
                {
                    yield return new Point(x, y);
                }
            }
        }
    }

    public bool Contains(T needle)
    {
        foreach (var line in Data)
        {
            if (line.Any(other => other?.Equals(needle) == true))
            {
                return true;
            }
        }
        return false;
    }
    
    // Data is a vertical array of rows first.
    // Reverse Y and X access order, to make the matrix easier to debug
    public T this[int x, int y]
    {
        get { return Data[y + OffsetY][x + OffsetX]; }
        set { Data[y + OffsetY][x + OffsetX] = value; }
    }

    public T this[Point p]
    {
        get {  return this[p.X, p.Y]; }
        set { this[p.X, p.Y] = value; }
    }

    public int Count(Func<T, bool> p)
    {
        var count = 0;
        foreach (var line in Data)
        {
            count += line.Count(p);
        }

        return count;
    }

    internal int Sum(Func<T, bool> predicate)
    {
        var count = 0;
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (predicate(this[x, y]))
                {
                    count++;
                }
            }
        }
        return count;
    }

    public bool Any(Func<T, bool> p)
    {
        foreach (var line in Data)
        {
            if (line.Any(p)) return true;
        }

        return false;
    }

    public string ToString(string separator = " ")
    {
        var sb = new StringBuilder();
        foreach(var line in Data)
        {
            foreach(var item in line)
            {
                sb.Append(item?.ToString() ?? "NULL");
                sb.Append(separator);
            }
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
}
