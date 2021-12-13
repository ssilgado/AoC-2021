namespace AdventOfCode.Solutions
{
    public class DayEightPartTwo
    {
        private static Dictionary<HashSet<char>, int> _charSetToNumber = new Dictionary<HashSet<char>, int>(HashSet<char>.CreateSetComparer())
        {
            {new HashSet<char>() {'a','b','c','e','f','g'}, 0},
            {new HashSet<char>() {'c','f'}, 1},
            {new HashSet<char>() {'a','c','d','e','g'}, 2},
            {new HashSet<char>() {'a','c','d','f','g'}, 3},
            {new HashSet<char>() {'b','c','d','f'}, 4},
            {new HashSet<char>() {'a','b','d','f','g'}, 5},
            {new HashSet<char>() {'a','b','d','e','f','g'}, 6},
            {new HashSet<char>() {'a','c','f'}, 7},
            {new HashSet<char>() {'a','b','c','d','e','f','g'}, 8},
            {new HashSet<char>() {'a','b','c','d','f','g'}, 9},
        };
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayEight.txt")
                .Select(line => line.Split('|'))
                .Select(line => line[0].Trim() + line[1])
                .Select(line => line.Split(' '))
                .Select(line => line.Select(word => word.ToCharArray()).ToArray())
                .ToList();

            var count = 0;
            foreach (var line in input)
            {
                var mapping = GetCharMapping(line);

                var rawSignals = new List<char[]>
                {
                    line[10],
                    line[11],
                    line[12],
                    line[13],
                };

                var convertedSingals = rawSignals.Select(signal =>
                {
                    var convertedSignal = new List<char>();
                    foreach (var character in signal)
                    {
                        convertedSignal.Add(mapping[character]);
                    }
                    return new HashSet<char>(convertedSignal.ToArray());
                });

                var number = "";
                foreach (var convertedSignal in convertedSingals)
                {
                    number += _charSetToNumber[convertedSignal];
                }

                count += int.Parse(number);
            }

            Console.WriteLine(count);
        }

        private static Dictionary<char, char> GetCharMapping(char[][] line)
        {
            var charMapping = new Dictionary<char, char>();

            List<HashSet<char>> segmentSignals = new List<HashSet<char>>()
            {
                new HashSet<char>(line[0]),
                new HashSet<char>(line[1]),
                new HashSet<char>(line[2]),
                new HashSet<char>(line[3]),
                new HashSet<char>(line[4]),
                new HashSet<char>(line[5]),
                new HashSet<char>(line[6]),
                new HashSet<char>(line[7]),
                new HashSet<char>(line[8]),
                new HashSet<char>(line[9]),
            };

            // Get signals with unique counts
            var oneSignal = segmentSignals.Where(segment => segment.Count() == 2).First();
            var fourSignal = segmentSignals.Where(segment => segment.Count() == 4).First();
            var sevenSignal = segmentSignals.Where(segment => segment.Count() == 3).First();
            var eightSignal = segmentSignals.Where(segment => segment.Count() == 7).First();

            // Get the remaining signals
            var twoThreeFiveSignals = segmentSignals.Where(segment => segment.Count() == 5).ToList();
            var zeroSixNineSignals = segmentSignals.Where(segment => segment.Count() == 6).ToList();

            // Obtain the char mapped to 'a'
            var sevenSignalCopy = new HashSet<char>(sevenSignal);
            sevenSignalCopy.ExceptWith(oneSignal);
            var aMappedValue = sevenSignalCopy.First();
            charMapping.Add(aMappedValue, 'a');

            // Obtain the char mapped to 'c' and 'f'
            var copy = new HashSet<char>(zeroSixNineSignals[0]);
            copy.IntersectWith(zeroSixNineSignals[1]);
            copy.IntersectWith(zeroSixNineSignals[2]);
            copy.IntersectWith(oneSignal);
            var fMappedValue = copy.First();
            var cMappedValue = new HashSet<char>(oneSignal).Except(new HashSet<char>() { fMappedValue }).First();
            charMapping.Add(fMappedValue, 'f');
            charMapping.Add(cMappedValue, 'c');

            // Obtain the char mapped to 'd'
            var fourSignalCopy = new HashSet<char>(fourSignal);
            foreach (var signal in twoThreeFiveSignals)
            {
                fourSignalCopy.IntersectWith(signal);
            }
            var dMappedValue = fourSignalCopy.First();
            charMapping.Add(dMappedValue, 'd');

            // Obtain the char mapped to 'g'
            copy = new HashSet<char>(twoThreeFiveSignals[0]);
            copy.IntersectWith(twoThreeFiveSignals[1]);
            copy.IntersectWith(twoThreeFiveSignals[2]);
            var gMappedValue = copy.Except(new HashSet<char>() { aMappedValue, dMappedValue }).First();
            charMapping.Add(gMappedValue, 'g');

            // Obtain the char mapped to 'b'
            var bMappedValue = new HashSet<char>(fourSignal).Except(new HashSet<char>() { cMappedValue, dMappedValue, fMappedValue }).First();
            charMapping.Add(bMappedValue, 'b');

            // Obtain the char mapped to 'e'
            var eMappedValue = new HashSet<char>(eightSignal).Except(new HashSet<char>() { aMappedValue, bMappedValue, cMappedValue, dMappedValue, fMappedValue, gMappedValue }).First();
            charMapping.Add(eMappedValue, 'e');

            return charMapping;
        }
    }
}