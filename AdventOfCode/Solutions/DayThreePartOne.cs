using System.Text;

namespace AdventOfCode.Solutions
{
    public class DayThreePartOne
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayThree.txt")
                .Select(line => line.ToCharArray().Select(c => c == '1' ? 1 : 0).ToArray())
                .ToList();
            
            var numberOfBits = input[0].Length;

            var oneBitCount = new int[numberOfBits];
            foreach (var binaryNum in input)
            {
                for (var i = 0; i < numberOfBits; i++)
                {
                    oneBitCount[i] += binaryNum[i];
                }
            }

            // Calculate ratio of 1s
            var ratio = new double[numberOfBits];
            for (var i = 0; i < numberOfBits; i++)
            {
                ratio[i] = (double) oneBitCount[i] / input.Count;
            }

            // Calculate gamma and epsilon by creating the binary string where in gamma is 1 and epsilon is 0 if the ratio is greater than 0.5
            var binaryGamma = new StringBuilder();
            var binaryEpsilon = new StringBuilder();
            for (var i = 0; i < numberOfBits; i++)
            {
                if (ratio[i] > 0.5)
                {
                    binaryGamma.Append('1');
                    binaryEpsilon.Append('0');
                }
                else
                {
                    binaryGamma.Append('0');
                    binaryEpsilon.Append('1');
                }
            }

            // Convert binary strings to unsigned integers
            var gamma = Convert.ToUInt32(binaryGamma.ToString(), 2);
            var epsilon = Convert.ToUInt32(binaryEpsilon.ToString(), 2);

            // Print solution
            Console.WriteLine(gamma * epsilon);
        }
    }
}