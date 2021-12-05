namespace AdventOfCode.Solutions
{
    public class DayFivePartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayFive.txt")
                .Select(line => line.Split(','))
                .Select(line => line.Select(int.Parse).ToArray())
                .ToList();

            // Filter out any lines that aren't vertical or horizontal
            var lines = input.Where(line => (line[0] == line[2] && line[1] != line[3]) || (line[1] == line[3] && line[0] != line[2])).
                ToList();

            // Find max x and y values of lines
            var maxX = lines.Max(line => Math.Max(line[0], line[2]));
            var maxY = lines.Max(line => Math.Max(line[1], line[3]));

            // Create a 2D array of 0s
            var grid = new int[maxX + 1, maxY + 1];

            // For each line, increment the grid values it crosses
            foreach (var line in lines)
            {
                if (line[0] == line[2])
                {
                    for (int i = Math.Min(line[1], line[3]); i <= Math.Max(line[1], line[3]); i++)
                    {
                        grid[line[0], i]++;
                    }
                }
                else
                {
                    for (int i = Math.Min(line[0], line[2]); i <= Math.Max(line[0], line[2]); i++)
                    {
                        grid[i, line[1]]++;
                    }
                }
            }

            // Find the number of grid points with more than one line crossing it
            var result = grid.Cast<int>().Where(x => x > 1).Count();
            
            // Print result
            Console.WriteLine(result);
        }
    }
}