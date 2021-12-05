namespace AdventOfCode.Solutions
{
    public class DayThreePartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayThree.txt")
                .Select(line => line.ToCharArray().Select(c => c == '1' ? 1 : 0).ToArray())
                .ToList();

            var numberOfBits = input[0].Length;

            // Create copies of the input
            var oxygenData = input.Select(line => line.ToArray()).ToList();
            var co2Data = input.Select(line => line.ToArray()).ToList();

            // Find oxygen and co2 binary value
            for (int i = 0; i < numberOfBits; i++)
            {
                var oxygenCriteriaInput = oxygenData.Select(line => line[i]).ToArray();
                var co2CriteriaInput = co2Data.Select(line => line[i]).ToArray();

                var oxygenCriteriaBit = OxygenBitCriteria(oxygenCriteriaInput);
                var co2CriteriaBit = CO2BitCriteria(co2CriteriaInput);

                if (oxygenData.Count != 1)
                {
                    oxygenData = oxygenData.Where(line => line[i] == oxygenCriteriaBit).ToList();
                }

                if (co2Data.Count != 1)
                {
                    co2Data = co2Data.Where(line => line[i] == co2CriteriaBit).ToList();
                }
            }

            // Convert first data value to unsigned int
            var oxygenDataValue = Convert.ToUInt32(String.Join("",oxygenData.First().Select(o => o.ToString()).ToArray()),2);
            var co2DataValue = Convert.ToUInt32(String.Join("",co2Data.First().Select(o => o.ToString()).ToArray()),2);

            // Print solution
            Console.WriteLine(oxygenDataValue * co2DataValue);
        }

        // This method will determine the bit for the oxygen criteria
        // If the frequency of ones is greater than or equal the frequency of zeros, then the bit is 1 else 0
        public static int OxygenBitCriteria(int[] input)
        {
            var ones = 0;
            var zeros = 0;
            foreach (var i in input)
            {
                if (i == 1)
                {
                    ones++;
                }
                else
                {
                    zeros++;
                }
            }

            return ones >= zeros ? 1 : 0;
        }

        // This method will determine the bit for the CO2 criteria
        // If the frequency of ones is less than the frequency of zeros, then the bit is 1 else 0
        public static int CO2BitCriteria(int[] input)
        {
            var ones = 0;
            var zeros = 0;
            foreach (var i in input)
            {
                if (i == 1)
                {
                    ones++;
                }
                else
                {
                    zeros++;
                }
            }

            return ones < zeros ? 1 : 0;
        }
    }
}