using System.Diagnostics;

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

    public int Day11Part1(string input)
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
    public int Day11Part2(string input)
    {
        var items = Parse(input);
        return 0;
    }
}

public class Monkey
{
    public List<int> _items = new List<int>();

    public int Id;
    public int Activity = 0;

    private Func<int, int> Operation;
    private int Divisor;
    private int TargetIfTrue;
    private int TargetIfFalse;

    public void Add(int i)
    {
        _items.Add(i);
    }

    public void AddRange(IEnumerable<int> i)
    {
        _items.AddRange(i);
    }

    public Dictionary<int, List<int>> Turn()
    {
        var output = new Dictionary<int, List<int>>();
        
        foreach (var item in _items)
        {
            Activity++; // inspected items X times    

            var result = Operation(item);
            
            result = result / 3; // trunc to int

            var key = (result % Divisor == 0)
                ? TargetIfTrue
                : TargetIfFalse;

            if (!output.ContainsKey(key))
            {
                output.Add(key, new List<int>());
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
        monkey.Id = int.Parse(id);

        var startingItems = input[1].Replace("Starting items: ", "").Split(",");
        monkey._items = startingItems.Select(int.Parse).ToList();

        var ops = input[2].Replace("Operation: new = old ", "").Split(" ").Skip(2).ToArray();
        if (int.TryParse(ops[1], out var operand)) {
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
        monkey.Divisor = int.Parse(div);

        var throw_true = input[4].Replace("If true: throw to monkey ", "");
        monkey.TargetIfTrue = int.Parse(throw_true);

        var throw_false = input[5].Replace("If false: throw to monkey ", "");
        monkey.TargetIfFalse = int.Parse(throw_false);

        return monkey;
    }

    public override string ToString()
    {
        return $"Monkey{Id}: {(string.Join(", ", _items))}";
    }
}