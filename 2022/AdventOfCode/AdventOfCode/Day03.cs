namespace AdventOfCode
{
    public class Day03
    {
        public static string[] Parse(string input)
        {
            var l = input.Length / 2;
            return new[]
            {
                input.Substring(0, l),
                input.Substring(l),
            };
        }

        private char FindDoubleItem(string[] input)
        {
            var index = 0;
            foreach(var item1 in input[0])
            {
                index++;
                if (input[1].Any(x => x == item1)) return item1;
            }
            throw new ArgumentException();
        }

        private int Priority(char c)
        {
            // A = 65
            // a = 97

            // Lowercase item types a through z have priorities 1 through 26.
            // Uppercase item types A through Z have priorities 27 through 52.
            var currentValue = (int)c;
            if (currentValue >= 97)
            {
                return currentValue - (int)'a' + 1; // 97 => 0 => 1
            } else
            {
                return currentValue - (int)'A' + 27; // 65 => 0 => 27
            }
        }

        public int Day03Part1(string input)
        {
            var total = 0;
            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var package = Day03.Parse(line);
                var doubleItem = FindDoubleItem(package); 
                total += Priority(doubleItem);
            }
            return total;
        }

        public int Day03Part2(string input)
        {
            var total = 0;
            var lines = input.Split(Environment.NewLine);
            var index = 0;
            while (index < lines.Length)
            {
                var group = lines.Skip(index).Take(3).ToArray();
                var badge = FindBadge(group);
                total += Priority(badge);
                index += 3;
            }
            return total;
        }

        private char FindBadge(string[] input)
        {
            var index = 0;
            foreach (var item1 in input[0])
            {
                index++;
                if (input[1].Any(item2 => item2 == item1) &&
                    input[2].Any(item3 => item3 == item1))
                {
                    return item1;
                }
            }
            throw new ArgumentException();
        }
    }
}
