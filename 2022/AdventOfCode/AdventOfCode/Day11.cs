using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace AdventOfCode;

public class Day11
{
    public static Monkey[] Parse(string input)
    {
        var blocks = input.Split(Environment.NewLine + Environment.NewLine);
        return blocks.Select(block => block.Split(Environment.NewLine))
            .Select(block => Monkey.Parse(block))
            .ToArray();
    }

    public long Day11Part1(string input)
    {
        var monkeys = Parse(input).ToDictionary(x => x.Id);

        for(var i = 0; i < 20; i ++)
        {
            foreach(var monkey in monkeys.Values)
            {
                var thrown = monkey.Turn();
                foreach(var item in thrown)
                {
                    monkeys[item.Key].AddRange(item.Value);
                }
            }

            Debug.WriteLine($"Turn {i + 1}:");
            foreach (var monkey in monkeys)
            {
                Debug.WriteLine(monkey.Value.ToString());
            }
        }

        var mostActive = monkeys.Values.OrderByDescending(m => m.Activity).Take(2).ToArray();

        return mostActive[0].Activity * mostActive[1].Activity;
    }

    public long Day11Part2(string input)
    {
        var breakpoints = new[] { 0, 19, 999, 8999, 9999 };

        var monkeys = Parse(input).ToDictionary(x => x.Id);

        var commonDenominator = MyMath.GreatestCommonDenominator(monkeys.Select(x => x.Value.Divisor).ToArray());

        for (var i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys.Values)
            {
                var thrown = monkey.Turn(false);
                foreach (var items in thrown)
                {
                    foreach(var item in items.Value)
                    {
                        var smallItem = item % commonDenominator;
                        monkeys[items.Key].Add(smallItem);
                    }
                }
            }

            if (breakpoints.Contains(i))
            {
                Debug.WriteLine($"Turn {i + 1}:");
                foreach (var monkey in monkeys)
                {
                    Debug.WriteLine(monkey.Value.ToString());
                }
            }
            //== After round 1000 ==
            //Monkey 0 inspected items 5204 times.
            //Monkey 1 inspected items 4792 times.
            //Monkey 2 inspected items 199 times.
            //Monkey 3 inspected items 5192 times.
        }

        var mostActive = monkeys.Values.OrderByDescending(m => m.Activity).Take(2).ToArray();

        return mostActive[0].Activity * mostActive[1].Activity;
    }
}

internal static class MyMath
{
    static long GCD(long n1, long n2)
    {
        if (n2 == 0)
        {
            return n1;
        }
        else
        {
            return GCD(n2, n1 % n2);
        }
    }

    public static long GreatestCommonDenominator(params long[] numbers)
    {
        return numbers.Aggregate((S, val) => S * val / GCD(S, val));
    }
}


public class Monkey
{
    public List<long> _items = new List<long>();

    public long Id;
    public long Activity = 0;

    private Func<long, long> Operation;
    public long Divisor;
    private long TargetIfTrue;
    private long TargetIfFalse;

    public void Add(long i)
    {
        _items.Add(i);
    }

    public void AddRange(IEnumerable<long> i)
    {
        _items.AddRange(i);
    }

    public Dictionary<long, List<long>> Turn(bool divide = true)
    {
        var output = new Dictionary<long, List<long>>();
        
        foreach (var item in _items)
        {
            Activity++; // inspected items X times    

            var result = Operation(item);

            if (divide)
            {
                result = result / 3; // trunc to long
            } 

            var key = (result % Divisor == 0)
                ? TargetIfTrue
                : TargetIfFalse;

            if (!output.ContainsKey(key))
            {
                output.Add(key, new List<long>());
            }
            output[key].Add(result);
        }
        _items.Clear();
        return output;
    }

    private Monkey() { }

    public static Monkey Parse(string[] input)
    {
        /*Monkey 0:
Starting items: 79, 98
Operation: new = old * 19
Test: divisible by 23
If true: throw to monkey 2
If false: throw to monkey 3

        */
        var monkey = new Monkey();

        var id = input[0].Replace("Monkey ", "").Replace(":", "");
        monkey.Id = long.Parse(id);

        var startingItems = input[1].Replace("Starting items: ", "").Split(",");
        monkey._items = startingItems.Select(long.Parse).ToList();

        var ops = input[2].Replace("Operation: new = old ", "").Split(" ").Skip(2).ToArray();
        if (long.TryParse(ops[1], out var operand)) {
            switch (ops[0])
            {
                case "+": monkey.Operation = (old) => old += operand; break;
                case "-": monkey.Operation = (old) => old -= operand; break;
                case "*": monkey.Operation = (old) => old *= operand; break;
                case "/": monkey.Operation = (old) => old /= operand; break;
                default:
                    throw new NotImplementedException();
            }
        } else
        {
            if (ops[1] != "old") 
                throw new NotImplementedException();
            switch (ops[0])
            {
                case "+": monkey.Operation = (old) => old += old; break;
                case "-": monkey.Operation = (old) => old -= old; break;
                case "*": monkey.Operation = (old) => old *= old; break;
                case "/": monkey.Operation = (old) => old /= old; break;
                default:
                    throw new NotImplementedException();
            }
        }

        var div = input[3].Replace("Test: divisible by ", "");
        monkey.Divisor = long.Parse(div);

        var throw_true = input[4].Replace("If true: throw to monkey ", "");
        monkey.TargetIfTrue = long.Parse(throw_true);

        var throw_false = input[5].Replace("If false: throw to monkey ", "");
        monkey.TargetIfFalse = long.Parse(throw_false);

        return monkey;
    }

    public override string ToString()
    {
        return $"Monkey{Id}: {Activity}, {(string.Join(", ", _items))}";
    }
}