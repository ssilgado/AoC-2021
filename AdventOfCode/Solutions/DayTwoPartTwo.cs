namespace AdventOfCode.Solutions
{
    public class DayTwoPartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayTwo.txt")
                .Select(o => o.Split(' '))
                .Select(o => new Tuple<string,int>(o[0], int.Parse(o[1])))
                .ToList();
            
            // Initialize x and z positions and aim
            var x = 0;
            var zDepth = 0;
            var aim = 0;

            // Loop through all the instructions, when 'forward' is encountered, increment x by the value and zDepth by the value times aim
            // When 'down' or 'up' is encountered, adjust aim by the value
            foreach (var instruction in input)
            {
                if (instruction.Item1 == "forward")
                {
                    x += instruction.Item2;
                    zDepth += instruction.Item2 * aim;

                    if (zDepth < 0)
                    {
                        zDepth = 0;
                    }
                }
                else if (instruction.Item1 == "up")
                {
                    aim -= instruction.Item2;
                }
                else if (instruction.Item1 == "down")
                {
                    aim += instruction.Item2;
                }
            }

            Console.WriteLine(Math.Abs(x) * Math.Abs(zDepth));
        }
    }
}