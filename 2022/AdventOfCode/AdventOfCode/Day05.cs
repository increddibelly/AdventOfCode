namespace AdventOfCode;

public class Day05
{
    public static List<Stack<string>> Parse(string input, out Instruction[] instructions)
    {
        var example = (input.StartsWith("    [D]"));
        return ParseState(example, input, out instructions);
    }
    
    private static List<Stack<string>> ParseState(bool example, string input, out Instruction[] instructions)
    {
        var lines = input.Split(Environment.NewLine);

        if (example)
        {
            /*
                [D]    
            [N] [C]    
            [Z] [M] [P]
             1   2   3 
             */

            instructions = lines.Skip(5).Select(item => new Instruction(item)).ToArray();
            return new List<Stack<string>>
            {
                new Stack<string>(), // start at index 1
                new Stack<string>( new [] { "Z", "N" } ),
                new Stack<string>( new [] { "M", "C", "D" } ),
                new Stack<string>( new [] { "P" } ),
            };
        }
        /*
        [F]         [L]     [M]            
        [T]     [H] [V] [G] [V]            
        [N]     [T] [D] [R] [N]     [D]    
        [Z]     [B] [C] [P] [B] [R] [Z]    
        [M]     [J] [N] [M] [F] [M] [V] [H]
        [G] [J] [L] [J] [S] [C] [G] [M] [F]
        [H] [W] [V] [P] [W] [H] [H] [N] [N]
        [J] [V] [G] [B] [F] [G] [D] [H] [G]
        */
        instructions = lines.Skip(10).Select(item => new Instruction(item)).ToArray();
        return new List<Stack<string>>
            {
                new Stack<string>(), // start at index 1
                new Stack<string>( new [] { "J", "H", "G", "M", "Z", "N", "T", "F" } ),
                new Stack<string>( new [] { "V", "W", "J" } ),
                new Stack<string>( new [] { "G", "V", "L", "J", "B", "T", "H" } ),
                new Stack<string>( new [] { "B", "P", "J", "N", "C", "D", "V", "L" } ),
                new Stack<string>( new [] { "F", "W", "S", "M", "P", "R", "G" } ),
                new Stack<string>( new [] { "G", "H", "C", "F", "B", "N", "V", "M" } ),
                new Stack<string>( new [] { "D", "H", "G", "M", "R" } ),
                new Stack<string>( new [] { "H", "N", "M", "V", "Z", "D" } ),
                new Stack<string>( new [] { "G", "N", "F", "H" } ),
            };
    }

    private static List<Stack<string>> Step(List<Stack<string>> state, Instruction instr, bool fancy = false)
    {
        if (!fancy)
        {
            for (var i = 0; i < instr.Count; i++)
            {
                var item = state[instr.From].Pop();
                state[instr.To].Push(item);
            }
            return state;
        }

        var items = new List<string>();
        for (var i = 0; i < instr.Count; i++)
        {
            var item = state[instr.From].Pop();
            items.Add(item);
        }
        items.Reverse();
        foreach(var item in items)
        {
            state[instr.To].Push(item);
        }
        return state;
    }

    public string Day05Part1(string input)
    {
        var state = Parse(input, out var instructions);
        foreach(var instr in instructions)
        {
            state = Step(state, instr);
        }
        return string.Concat(state.Skip(1).Select(s => s.Pop()));
    }

    public string Day05Part2(string input)
    {
        var state = Parse(input, out var instructions);
        foreach (var instr in instructions)
        {
            state = Step(state, instr, true);
        }
        return string.Concat(state.Skip(1).Select(s => s.Pop()));
    }
}

public class Instruction
{
    public readonly int Count;
    public readonly int From;
    public readonly int To;
    public Instruction(string input) 
    {
        // move x from y to z
        var items = input.Split(" ");
        Count = int.Parse(items[1]);
        From = int.Parse(items[3]);
        To = int.Parse(items[5]);
    }
}
