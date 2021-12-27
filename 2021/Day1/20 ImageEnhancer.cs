using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles;

public class ImageEnhancer
{
    protected string Lookup { get; set; }

    public ImageEnhancer(string input = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..##")
    {
        Lookup = input;
    }


}
