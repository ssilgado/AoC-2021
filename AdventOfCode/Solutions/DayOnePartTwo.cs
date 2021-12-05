namespace AdventOfCode.Solutions
{
    public class DayOnePartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayOne.txt").Select(int.Parse).ToList();
            
            var depthIncrementCounter = 0;
            for (int i = 0; i < input.Count-3; i++)
            {
                var firstWindow = input[i] + input[i + 1] + input[i + 2];
                var secondWindow = input[i + 1] + input[i + 2] + input[i + 3];
                if (secondWindow > firstWindow)
                {
                    depthIncrementCounter++;
                }
            }

            Console.WriteLine(depthIncrementCounter);
        }
    }
}