using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day13
{
    private string[][] Parse(string input)
    {
        var groups = input.Split(Environment.NewLine+Environment.NewLine);
        var pairs = groups.Select(gr => gr.Split(Environment.NewLine)).ToArray();
        return pairs;
    }

    public int Day13Part1(string input)
    {
        var pairs = Parse(input);
        var correctOrders = new List<int>();
        for(var index = 0; index < pairs.Length; index++)
        {
            if (CorrectOrder(pairs[index]))
            {
                correctOrders.Add(index + 1); // one based
            }
        }
        return correctOrders.Sum();
    }

    private bool CorrectOrder(string[] pair)
    {
        var first = pair[0];
        var second = pair[1];

        var si = -1;
        for (var i = 0; i < first.Length-1; i++)
        {
            si++;
            if (second.Length <= si) {
                return false;
            }

            if (second.Length == si + 1 && first.Length > i + 1)
            {
                // left has more items
                return false;
            }

            var firstValue = first[i];
            var secondValue = second[si];
            
            // identical values are nicest
            if (secondValue == firstValue)
                continue;

            if (secondValue == '[')
            {
                i--; // let's imagine first also opens a list, this takes one character, so one step to catch up.
                continue;
            }
            if (firstValue == '[')
            {
                si--; // let's imagine second also opens a list, this takes one character, so one step.
                continue;
            }

            if (secondValue == ']')
            {
                if (int.TryParse(firstValue.ToString(), out var _))
                    return false;
                i--;
                continue;
            }

            if (firstValue == ']')
            {
                if (int.TryParse(secondValue.ToString(), out var _))
                    return true;
                si--;
                continue;
            }
            
            if (secondValue < firstValue)
                return false;

            if (secondValue > firstValue)
                return true;
        }
        return true;
    }

    private List<int>

    public int Day13Part2(string input)
    {
        return 0;
    }
}
