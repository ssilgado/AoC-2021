using System.Numerics;

namespace AdventOfCode.Solutions
{
    public class DaySixPartTwo
    {
        private static IDictionary<Tuple<int,int>, BigInteger> _lanternFishMap = new Dictionary<Tuple<int,int>, BigInteger>();
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DaySix.txt")
                .Select(line => line.Split(','))
                .SelectMany(num => num)
                .Select(int.Parse)
                .ToList();

            var numberOfDays = 256;
            var count = BigInteger.Zero;

            foreach (var initialFishState in input)
            {
                count += GetLanternFishCount(numberOfDays, initialFishState);
            }

            Console.WriteLine(count);
        }

        private static BigInteger GetLanternFishCount(int numDays, int fishState)
        {
            if (numDays == 0) return 1;

            var key = new Tuple<int, int>(numDays, fishState);
            if (_lanternFishMap.ContainsKey(key))
            {
                return _lanternFishMap[key];
            } else
            {
                var fishCount = BigInteger.Zero;
                if (fishState != 0) {
                    fishCount = GetLanternFishCount(numDays-1, fishState-1);
                    _lanternFishMap.Add(key, fishCount);
                } else
                {
                    fishCount = GetLanternFishCount(numDays-1, 6) + GetLanternFishCount(numDays-1, 8);
                    _lanternFishMap.Add(key, fishCount);
                }

                return fishCount;
            }
        }
    }
}