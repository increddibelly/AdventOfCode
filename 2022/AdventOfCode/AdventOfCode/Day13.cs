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
        for (var index = 0; index < pairs.Length; index++)
        {
            var pair = pairs[index];
            var firstNumbers = pair[0].Replace("[", "").Replace("]", "").Split(",").Select(int.Parse).ToArray() ?? new[] {} ;
            var secondNumbers = pair[1].Replace("[", "").Replace("]", "").Split(",")?.Select(int.Parse).ToArray();

            if (CorrectOrder(firstNumbers, secondNumbers))
            {
                correctOrders.Add(index + 1); // one based
                continue;
            }


            //if (CorrectOrder(pairs[index]))
            //{
            //    correctOrders.Add(index + 1); // one based
            //}
        }
        return correctOrders.Sum();
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

            if (second.Length == si + 1 && first.Length > i + 1)
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
                // if first has a number and second is closing, first is larger
                if (int.TryParse(firstValue.ToString(), out var _))
                    return false;
                // wait for second to close
                i--;
                continue;
            }

            if (firstValue == ']')
            {
                // if second has a number and first is closing, second is larger
                if (int.TryParse(secondValue.ToString(), out var _))
                    return true;
                // wait for first to close
                si--;
                continue;
            }

            //if (firstValue == ',')
            //{
            //    return false;
            //}

            //if (secondValue == ',')
            //{
            //    return true;
            //}

            // now we get to the acutal numbers
            var firstDigits = first.Skip(i).TakeWhile(c => "0123456789".Contains(c)).ToArray();
            var firstIsNumber = int.TryParse(new string(firstDigits), out var firstNumber);
            var secondDigits = second.Skip(si).TakeWhile(c => "0123456789".Contains(c)).ToArray();
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
            second.Skip(si).Any(c => "0123456789".Contains(c));
    }

    public int Day13Part2(string input)
    {
        return 0;
    }
}
