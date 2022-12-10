using System.Text;

namespace AdventOfCode
{
    public class Day10
    {
        public static IReadOnlyList<IInstruction> Parse(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var program = new List<IInstruction>(lines.Length);
            foreach(var line in lines)
            {
                var ops = line.Split(" ");
                switch(ops[0])
                {
                    case "noop":
                        program.Add(new Noop(0)); break;
                    case "addx":
                        program.Add(new AddX(int.Parse(ops[1]))); break;
                }
            }
            return program;
        }

        public int Day10Part1(IReadOnlyList<IInstruction> instructions)
        {
            var t = 0;
            var codePointer = 0;

            var registerX = 1;
            var interestingSignals = new List<int>();
            IInstruction? currentInstruction = null;

            do
            {
                t++;
                if (t % 40 == 20)
                {
                    /*
                    During the 20th cycle, register X has the value 21, so the signal strength is 20 * 21 = 420.
                    During the 60th cycle, register X has the value 19, so the signal strength is 60 * 19 = 1140.
                    During the 100th cycle, register X has the value 18, so the signal strength is 100 * 18 = 1800.
                    During the 140th cycle, register X has the value 21, so the signal strength is 140 * 21 = 2940.
                    During the 180th cycle, register X has the value 16, so the signal strength is 180 * 16 = 2880.
                    During the 220th cycle, register X has the value 18, so the signal strength is 220 * 18 = 3960
                     */
                    var signal = t * registerX;
                    interestingSignals.Add(signal);
                }

                currentInstruction = currentInstruction ?? instructions[codePointer++];

                // execute running instruction;
                registerX = currentInstruction.Execute(registerX);
                

                if (currentInstruction.Done)
                {
                    if (codePointer >= instructions.Count)
                        currentInstruction = null; 
                    else
                        currentInstruction = instructions[codePointer++];
                }
            } while (codePointer < instructions.Count);
            return interestingSignals.Sum();
        }

        public string Day10Part2(IReadOnlyList<IInstruction> instructions, string blank = ".")
        {
            var t = 0;
            var codePointer = 0;

            var registerX = 1;
            IInstruction? currentInstruction = null;
            var output = new StringBuilder();
            do
            {
                currentInstruction = currentInstruction ?? instructions[codePointer++];

                if ((t % 40) >= (registerX - 1) && (t % 40) <= (registerX + 1))
                {
                    // sprite hits
                    output.Append("#");
                }
                else
                {
                    output.Append(blank);
                }
                t++;

                // execute running instruction;
                registerX = currentInstruction.Execute(registerX);

                if (currentInstruction.Done)
                {
                    if (codePointer >= instructions.Count)
                        currentInstruction = null;
                    else
                        currentInstruction = instructions[codePointer++];
                }

                if (t % 40 == 0)
                {
                    output.Append(Environment.NewLine);
                }
            } while (codePointer < instructions.Count);

            if ((t % 40) >= (registerX - 1) && (t % 40) <= (registerX + 1))
            {
                // sprite hits
                output.Append("#");
            }
            else
            {
                output.Append(blank);
            }
            t++;

            return output.ToString();
        }
    }

    public interface IInstruction
    {
        int CyclesRemaining { get; }
        int Value { get; }
        bool Done { get; }

        int Execute(int register);
    }

    public class Noop : IInstruction
    {
        public int CyclesRemaining { get; protected set; } = 1;
        public int Value { get; protected set; }

        public bool Done => CyclesRemaining <= 0;

        public Noop(int value)
        {
            Value = value;
        }

        public int Execute(int register)
        {
            --CyclesRemaining;
            return register;
        }

        public override string ToString()
        {
            return $"Noop => No change";
        }
    }

    public class AddX : IInstruction
    {
        public int CyclesRemaining { get; protected set; } = 2;
        
        public bool Done => CyclesRemaining <= 0;

        public int Value { get; protected set; }

        public AddX(int value)
        {
            Value = value;
        }

        public int Execute(int register)
        {
            if (--CyclesRemaining == 0) {
                return register + Value;
            }
            return register;
        }

        public override string ToString()
        {
            return $"AddX => Add {Value} in {CyclesRemaining} cycles";
        }
    }
}
