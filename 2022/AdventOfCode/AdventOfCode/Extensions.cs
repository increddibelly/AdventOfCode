using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public static class Extensions
{
    public static void AddRange<T>(this HashSet<T> source, IEnumerable<T> target)
    {
        foreach (var item in target)
        {
            source.Add(item);
        }
    }
}
