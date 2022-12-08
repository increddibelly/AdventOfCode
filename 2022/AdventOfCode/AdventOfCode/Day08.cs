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

            for (var treeX = 0; treeX < map.XSize; treeX++)
            {
                for (var treeY = 0; treeY < map.YSize; treeY++)
                {
                    var currentTreeHeight = map[treeX, treeY];

                    var leftVisible = true; 
                    var topVisible = true;
                    var rightVisible = true; 
                    var bottomVisible = true;

                    for (var x = 0; x < map.XSize; x++)
                    {
                        for (var y = 0; y < map.XSize; y++)
                        {
                            if (treeX != x && treeY != y)
                                continue; // we're checking diagonally. Don't. This is quicker than lots of complicated loops

                            // check if there's ANY path to the edge

                            if (x == treeX && y == treeY)
                            {
                                if (leftVisible || topVisible)
                                {
                                    // this one is visible from the top left area.
                                    x = map.XSize;
                                    y = map.YSize;
                                    break;
                                }
                            }

                            if (x == 0 || y == 0 || x == map.XSize || y == map.YSize)
                            {
                                leftVisible = true; // may not be correct for the bottom right edges but the outcome is the same
                                x = map.XSize;
                                y = map.YSize;
                                break;
                            }

                            // start at edges, work way in
                            if (map[x, y] >= currentTreeHeight)
                            {
                                if (x < treeX)
                                {
                                    leftVisible = false;
                                    x = treeX; // skip a bit here
                                }
                                if (x > treeX)
                                {
                                    rightVisible = false;
                                    x = map.XSize; // skip a bit here
                                }

                                if (y < treeX)
                                {
                                    topVisible = false;
                                    y = treeY; // skip a bit here
                                }
                                if (y > treeY)
                                {
                                    bottomVisible = false;
                                    y = map.YSize; // skip a bit here
                                }
                            }
                        }
                    }
                    
                    if (leftVisible || rightVisible || topVisible || bottomVisible) 
                    {
                        visibles.Add(new Point(treeX, treeY));
                    }
                }
            }
            return visibles.Count;
        }

        public int Day08Part2(string[] input)
        {
            return 0;
        }
    }
}
