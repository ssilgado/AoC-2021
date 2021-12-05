namespace AdventOfCode.Solutions
{
    public class DayTwoPartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayTwo.txt")
                .Select(o => o.Split(' '))
                .Select(o => new Tuple<string,int>(o[0], int.Parse(o[1])))
                .ToList();
            
            // Initialize x and z positions
            var x = 0;
            var z = 0;

            // Iterate over the inputs, adjusting x if 'forward' and z if 'up' or 'down'
            foreach (var commands in input)
            {
                if (commands.Item1 == "up")
                {
                    z += commands.Item2;
                }
                else if (commands.Item1 == "down")
                {
                    z -= commands.Item2;
                }
                else if (commands.Item1 == "forward")
                {
                    x += commands.Item2;
                }
            }

            Console.WriteLine(x*z*-1);
        }
    }
}