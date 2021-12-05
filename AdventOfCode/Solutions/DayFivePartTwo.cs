namespace AdventOfCode.Solutions
{
    public class DayFivePartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayFive.txt")
                .Select(line => line.Split(','))
                .Select(line => line.Select(int.Parse).ToArray())
                .ToList();

            // Find max x and y values of lines
            var maxX = input.Max(line => Math.Max(line[0], line[2]));
            var maxY = input.Max(line => Math.Max(line[1], line[3]));

            // Create a 2D array of 0s
            var grid = new int[maxX + 1, maxY + 1];

            // For each line, increment the grid values it crosses
            foreach (var line in input)
            {
                if (line[0] == line[2])
                {
                    for (int i = Math.Min(line[1], line[3]); i <= Math.Max(line[1], line[3]); i++)
                    {
                        grid[line[0], i]++;
                    }
                }
                else if (line[1] == line[3])
                {
                    for (int i = Math.Min(line[0], line[2]); i <= Math.Max(line[0], line[2]); i++)
                    {
                        grid[i, line[1]]++;
                    }
                } else {
                    var slope = 0;
                    var initialX = 0;
                    var initialY = 0;
                    if (line[0] < line[2])
                    {
                        slope = (line[3] - line[1]) / (line[2] - line[0]);
                        initialX = line[0];
                        initialY = line[1];
                    }
                    else
                    {
                        slope = (line[1] - line[3]) / (line[0] - line[2]);
                        initialX = line[2];
                        initialY = line[3];
                    }

                    for (int i = 0; Math.Abs(i) <= Math.Abs(line[2] - line[0]); i += slope)
                    {
                        grid[initialX + Math.Abs(i), initialY + i]++;
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