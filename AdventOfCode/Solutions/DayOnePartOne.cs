namespace AdventOfCode.Solutions
{
    public class DayOnePartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayOne.txt").Select(int.Parse).ToList();
            
            var depthIncrementCounter = 0;
            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] > input[i - 1])
                {
                    depthIncrementCounter++;
                }
            }

            Console.WriteLine(depthIncrementCounter);
        }
    }
}