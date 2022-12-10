using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day09
    {
        Point T, H;

        List<Point> knots = new List<Point>();

        List<Point> visited = new List<Point>();

        public string[] Parse(string input)
        {
            return input.Split(Environment.NewLine);
        }

        public int Day09Part1(string[] input)
        {
            T = new Point(0, 0);
            H = new Point(0, 0);
            visited.Add(T);
            foreach(var line in input)
            {
                var direction = line[0].ToString();
                var steps = int.Parse(line.Substring(2));

                for (var i = 0; i < steps; i++)
                {
                    Move(ref H, direction);
                    Follow(H, ref T);
                }
            }
            return visited.Distinct().Count();
        }

        private void Move(ref Point p, string direction)
        {
            switch(direction)
            {
                case "L" : p.X -= 1; break;
                case "R" : p.X += 1; break;
                case "U" : p.Y -= 1; break;
                case "D" : p.Y += 1; break;
            }
        }
        
        private void Follow(Point head, ref Point tail, bool track = true)
        {
            var dx = head.X - tail.X;
            var dy = head.Y - tail.Y;
            if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
            {
                dx = dx == 0 ? 0 : dx / Math.Abs(dx);
                dy = dy == 0 ? 0 : dy / Math.Abs(dy);

                tail.X += dx;
                tail.Y += dy;

                if (track)
                {
                    visited.Add(tail);
                }
            }
        }

        public int Day09Part2(string[] input)
        {
            var head = new Point(0, 0);
            var h1 = new Point(0, 0);
            var h2 = new Point(0, 0);
            var h3 = new Point(0, 0);
            var h4 = new Point(0, 0);
            var h5 = new Point(0, 0);
            var h6 = new Point(0, 0);
            var h7 = new Point(0, 0);
            var h8 = new Point(0, 0);
            var tail = new Point(0, 0);
            visited.Add(tail);
            foreach (var line in input)
            {
                var direction = line[0].ToString();
                var steps = int.Parse(line.Substring(2));

                for (var i = 0; i < steps; i++)
                {
                    Move(ref head, direction);
                    Follow(head, ref h1, false);
                    Follow(h1, ref h2, false);
                    Follow(h2, ref h3, false);
                    Follow(h3, ref h4, false);
                    Follow(h4, ref h5, false);
                    Follow(h5, ref h6, false);
                    Follow(h6, ref h7, false);
                    Follow(h7, ref h8, false);
                    Follow(h8, ref tail);
                }
            }
            return visited.Distinct().Count();
        }
    }
}
