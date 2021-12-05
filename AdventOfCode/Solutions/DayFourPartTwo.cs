namespace AdventOfCode.Solutions
{
    public class DayFourPartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayFour.txt").ToList();

            var drawnNumbers = input[0].Split(',').Select(int.Parse).ToList();

            input.RemoveAt(0);
            input.RemoveAt(0);

            var bingoBoards = new List<BingoBoard>();
            var currentBoard = new List<int[]>();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Equals(""))
                {
                    int[,] convertedBoard = new int[currentBoard.Count, currentBoard.Max(x => x.Length)];
                    for (int j = 0; j < currentBoard.Count; j++)
                    {
                        for (int k = 0; k < currentBoard[j].Length; k++)
                        {
                            convertedBoard[j, k] = currentBoard[j][k];
                        }
                    }

                    bingoBoards.Add(new BingoBoard(convertedBoard));
                    currentBoard = new List<int[]>();
                }
                else
                {
                    currentBoard.Add(input[i].Split(' ').Select(int.Parse).ToArray());
                }
            }

            foreach (var number in drawnNumbers)
            {
                foreach (var board in bingoBoards)
                {
                    board.Mark(number);
                }

                if (bingoBoards.Count != 1) bingoBoards.RemoveAll(x => x.IsBingo());

                if (bingoBoards.Count == 1 && bingoBoards[0].IsBingo())
                {
                    Console.WriteLine(bingoBoards[0].GetUnmarkedSum() * number);
                    return;
                }
            }
        }
    }
}