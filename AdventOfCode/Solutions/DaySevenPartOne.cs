namespace AdventOfCode.Solutions
{
    public class DaySevenPartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DaySeven.txt")
                .Select(line => line.Split(','))
                .SelectMany(num => num)
                .Select(int.Parse)
                .ToList();

            // Get the max and min values
            var max = input.Max();
            var min = input.Min();

            // Dictionary to store the movement values
            var movement = new Dictionary<int, int>();
            for (var i = min; i <= max; i++)
            {
                movement.Add(i, 0);
            }

            // Loop through the input and add the distance from the current value to the key
            for (var i = 0; i < input.Count; i++)
            {
                for (var j = min; j <= max; j++)
                {
                    movement[j] += Math.Abs(input[i] - j);
                }
            }

            // Get the lowest value
            var lowest = movement.OrderBy(x => x.Value).First().Value;

            // Print the solution
            Console.WriteLine(lowest);
        }
    }
}