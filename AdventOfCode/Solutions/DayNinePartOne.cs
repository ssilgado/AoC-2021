namespace AdventOfCode.Solutions
{
    public class DayNinePartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayNine.txt")
                .Select(line => line.ToCharArray())
                .Select(line => line.Select(c => Int32.Parse(c.ToString())).ToArray())
                .ToArray();
            
            var lowPoints = new List<int>();

            // Find points where adjacent numbers are above the current number
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    if (i == 0)
                    {
                        if(j == 0)
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(input[i][j]);
                        } else
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        }
                    } else if (i == input.Length - 1)
                    {
                        if (j == 0)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(input[i][j]);
                        } else
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        }
                    } else
                    {
                        if (j == 0)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(input[i][j]);
                        } else
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(input[i][j]);
                        }
                    }
                }
            }

            var result = lowPoints.Sum() + lowPoints.Count();
            Console.WriteLine(result);
        }
    }
}