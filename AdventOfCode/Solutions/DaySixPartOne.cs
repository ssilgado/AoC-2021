namespace AdventOfCode.Solutions
{
    public class DaySixPartOne
    {
        private static IDictionary<Tuple<int,int>, int> _lanternFishMap = new Dictionary<Tuple<int,int>, int>();
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DaySix.txt")
                .Select(line => line.Split(','))
                .SelectMany(num => num)
                .Select(int.Parse)
                .ToList();

            var numberOfDays = 80;
            var count = 0;

            foreach (var initialFishState in input)
            {
                count += GetLanternFishCount(numberOfDays, initialFishState);
            }

            Console.WriteLine(count);
        }

        private static int GetLanternFishCount(int numDays, int fishState)
        {
            if (numDays == 0) return 1;

            var key = new Tuple<int, int>(numDays, fishState);
            if (_lanternFishMap.ContainsKey(key))
            {
                return _lanternFishMap[key];
            } else
            {
                var fishCount = 0;
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