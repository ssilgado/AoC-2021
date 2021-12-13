namespace AdventOfCode.Solutions
{
    public class DayEightPartOne
    {
        private static IList<int> _uniqueLengthDigits = new List<int>(){
            2,4,3,7
        };
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayEight.txt")
                .Select(line => line.Split('|'))
                .Select(line => line[1].Trim())
                .Select(line => line.Split(' '))
                .SelectMany(line => line)
                .ToList();

            var signalsToCount = input.Select(line => line.Length)
                .Select(length => _uniqueLengthDigits.Contains(length) ? 1 : 0)
                .ToList();
            
            var sum = signalsToCount.Sum(); 

            Console.WriteLine(sum);
        }
    }
}