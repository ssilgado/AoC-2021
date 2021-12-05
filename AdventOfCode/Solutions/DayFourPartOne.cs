namespace AdventOfCode.Solutions
{
    public class DayFourPartOne
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

                var winningBoard = bingoBoards.Where(x => x.IsBingo()).FirstOrDefault();

                if (winningBoard != null)
                {
                    Console.WriteLine(winningBoard.GetUnmarkedSum() * number);
                    return;
                }
            }
        }
    }

    public class BingoBoard
    {
        public int[,] Board { get; set; }
        public bool[,] MarkedBoard { get; set; }

        public BingoBoard(int[,] board)
        {
            Board = board;
            MarkedBoard = new bool[Board.GetLength(0), Board.GetLength(1)];
        }

        // Returns true if any row or column in marked has all true values
        public bool IsBingo()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (IsRowBingo(i))
                {
                    return true;
                }
            }

            for (int i = 0; i < Board.GetLength(1); i++)
            {
                if (IsColumnBingo(i))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsRowBingo(int row)
        {
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                if (!MarkedBoard[row, i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsColumnBingo(int column)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (!MarkedBoard[i, column])
                {
                    return false;
                }
            }

            return true;
        }

        // This method marks the board with the given number
        public void Mark(int number)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == number)
                    {
                        MarkedBoard[i, j] = true;
                    }
                }
            }
        }

        // Returns the sum of all unmarked numbers in the board
        public int GetUnmarkedSum()
        {
            var sum = 0;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (!MarkedBoard[i, j])
                    {
                        sum += Board[i, j];
                    }
                }
            }

            return sum;
        }
    }
}