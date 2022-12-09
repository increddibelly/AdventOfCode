using System.Drawing;

#nullable disable
namespace AdventOfCode
{
    public class Day08
    {
        public Map<int> Parse(string input)
        {
            return Map<int>.Parse(input, c => int.Parse(c.ToString()), Environment.NewLine);
        }

        public int Day08Part1(Map<int> map)
        {
            var visibles = new List<Point>();

            for (var treeY = 0; treeY < map.YSize; treeY++)
            {
                for (var treeX = 0; treeX < map.XSize; treeX++)
                {
                    var currentTreeHeight = map[treeX, treeY];
                    var visible = false;

                    var row = map.Row(treeY);
                    var col = map.Column(treeX);

                    var x = 0;
                    var y = 0;
                    var xHeights = row.ToDictionary(h => x++, h => h);
                    var yHeights = col.ToDictionary(h => y++, h => h);
                    if (xHeights.Where(x => x.Key < treeX).All(x => x.Value < currentTreeHeight))
                    {
                        // visible from Left;
                        visible = true;
                    }
                    if (xHeights.Where(x => x.Key > treeX).All(x => x.Value < currentTreeHeight))
                    {
                        // visible from Right;
                        visible = true;
                    }
                    if (yHeights.Where(y => y.Key < treeY).All(x => x.Value < currentTreeHeight))
                    {
                        // visible from Top;
                        visible = true;
                    }
                    if (yHeights.Where(y => y.Key > treeY).All(x => x.Value < currentTreeHeight))
                    {
                        // visible from Bottom;
                        visible = true;
                    }

                    if (visible)
                    {
                        visibles.Add(new Point(x, y));
                        continue;
                    }

                    // 3 0 3 7 3 = + + + + +
                    // 2 5 5 1 2 = + + + - +
                    // 6 5 3 3 2 = + + - + +
                    // 3 3 5 4 9 = + - + - +
                    // 3 5 3 9 0 = + + + + +
                }
            }
            visibles = visibles.OrderBy(x => x.Y).ToList();
            return visibles.Count;
        }

        public int Day08Part2(Map<int> map)
        {
            var bestView = 0;

            for (var treeY = 0; treeY < map.YSize; treeY++)
            {
                for (var treeX = 0; treeX < map.XSize; treeX++)
                {
                    var currentTreeHeight = map[treeX, treeY];
                    var visible = false;

                    var row = map.Row(treeY);
                    var col = map.Column(treeX);

                    var x = 0;
                    var y = 0;
                    var xHeights = row.ToDictionary(h => x++, h => h);
                    var yHeights = col.ToDictionary(h => y++, h => h);

                    var viewLeft = 0;
                    var viewRight = 0;
                    var viewTop = 0;
                    var viewBottom = 0;

                    for (x = treeX-1; x >= 0; x--)
                    {
                        viewLeft++;
                        if (xHeights[x] >= currentTreeHeight) break;
                    }

                    for (x = treeX+1; x < xHeights.Count; x++)
                    {
                        viewRight++;
                        if (xHeights[x] >= currentTreeHeight) break;
                    }

                    for (y = treeY-1; y >= 0; y--)
                    {
                        viewTop++;
                        if (yHeights[y] >= currentTreeHeight) break;
                    }

                    for (y = treeY+1; y < yHeights.Count; y++)
                    {
                        viewBottom++;
                        if (yHeights[y] >= currentTreeHeight) break;
                    }

                    var score = viewLeft * viewRight * viewTop * viewBottom;
                    if (score > bestView)
                        bestView = score;

                    // 3 0 3 7 3 = + + + + +
                    // 2 5 5 1 2 = + + + - +
                    // 6 5 3 3 2 = + + - + +
                    // 3 3 5 4 9 = + - + - +
                    // 3 5 3 9 0 = + + + + +
                }
            }
            return bestView;
        }

        public int Day08Part2(string[] input)
        {
            return 0;
        }
    }
}
