using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day13
{
    private const string Numbers = "0123456789";

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
        for (var index = 0; index < pairs.Length; index++)
        {
            var pair = pairs[index];

            pair = Reconstruct(pair);

            if (CorrectOrder(pair))
            {
                correctOrders.Add(index + 1); // one based
            }
        }
        return correctOrders.Sum();
    }

    private string[] Reconstruct(string[] pair)
    {
        var left = new StringBuilder(pair[0]);
        var right = new StringBuilder(pair[1]);

        var si = -1;
        for(var i = 0; i<left.Length; i++)
        {
            if (++si >= right.Length - 1)
                break;

            var l = left[i];
            var r = right[si];

            if (l == r)
                continue;

            // upgrade a single number to a list with that number
            if (l == '[')
            {
                right.Insert(si++, l);
                while (Numbers.Contains(r))
                {
                    r = right[++si];
                }
                right.Insert(si, ']');
            }

            // upgrade a single number to a list with that number
            if (r == '[')
            {
                left.Insert(i++, r);
                while (Numbers.Contains(l))
                {
                    l = left[++i];
                }
                left.Insert(i, ']');
            }
        }

        return new[]
        {
            left.ToString(),
            right.ToString()
        };
    }

    private bool CorrectOrder(int[] firstNumbers, int[] secondNumbers)
    {
        for(var i = 0; i<firstNumbers.Length; i++)
        {
            if (secondNumbers.Length <= i)
                return false;

            var second = secondNumbers[i];
            var first = firstNumbers[i];

            if (second < first) 
                return false;
            if (second > first) 
                return true;
        }
        // second has more number
        return secondNumbers.Length > firstNumbers.Length;
    }

    public int Day13Part3(string input)
    {
        var pairs = Parse(input);
        var correctOrders = new List<int>();
        for (var index = 0; index < pairs.Length; index++)
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

            if (si == second.Length - 1 && first.Length > i)
            {
                // last index of second, but first still has more items
                return false;
            }

            var firstValue = first[i];
            var secondValue = second[si];
            
            // identical values are nicest
            if (secondValue == firstValue)
                continue;

            if (secondValue == '[')
            {
                i--; // let's imagine first also opens a list, this takes one additional character, so one step to catch up.
                continue;
            }
            if (firstValue == '[')
            {
                si--; // let's imagine second also opens a list, this takes one additional character, so one step.
                continue;
            }

            if (secondValue == ']')
            {
                if (Numbers.Contains(firstValue) || first.Length > i)
                    return false;
                // wait for second to close
                i--;
                continue;
            }

            if (firstValue == ']')
            {
                if (Numbers.Contains(secondValue) || second.Length > si)
                    return true;
                // wait for first to close
                si--;
                continue;
            }

            if (firstValue == ',')
            {
                return false;
            }

            if (secondValue == ',')
            {
                return true;
            }

            // now we get to the acutal numbers
            var firstDigits = first.Skip(i).TakeWhile(c => Numbers.Contains(c)).ToArray();
            var firstIsNumber = int.TryParse(new string(firstDigits), out var firstNumber);
            var secondDigits = second.Skip(si).TakeWhile(c => Numbers.Contains(c)).ToArray();
            var secondIsNumber = int.TryParse(new string(secondDigits), out var secondNumber);

            if (firstIsNumber && !secondIsNumber)
                return false;

            if (!firstIsNumber && secondIsNumber)
                return true;

            if (!firstIsNumber && !secondIsNumber)
            {
                // dafuq
                return secondValue > firstValue; // whatever man
            }

            if (secondNumber == firstNumber)
                continue;

            return (secondNumber > firstNumber);
        }

        // if second has ANY numbers left in whatever form, it is the larger one
        return
            second.Length > si;
    }

    public int Day13Part2(string input)
    {
        return 0;
    }
}
