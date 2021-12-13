namespace AdventOfCode.Solutions
{
    public class DayNinePartTwo
    {
        public static void PrintSolution()
        {
            var input = File.ReadAllLines("./Inputs/DayNine.txt")
                .Select(line => line.ToCharArray())
                .Select(line => line.Select(c => Int32.Parse(c.ToString())).ToArray())
                .ToArray();
            
            var lowPoints = new List<Tuple<int,int, int>>();
            var width = input[0].Length;
            var height = input.Length;

            // Find points where adjacent numbers are above the current number
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    if (i == 0)
                    {
                        if(j == 0)
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else
                        {
                            if (input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        }
                    } else if (i == input.Length - 1)
                    {
                        if (j == 0)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        }
                    } else
                    {
                        if (j == 0)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else if (j == input[i].Length - 1)
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        } else
                        {
                            if (input[i][j] < input[i - 1][j] && input[i][j] < input[i + 1][j] && input[i][j] < input[i][j - 1] && input[i][j] < input[i][j + 1]) lowPoints.Add(new Tuple<int, int, int>(i, j,input[i][j]));
                        }
                    }
                }
            }

            Dictionary<Tuple<int, int, int>, int> basinSize = new Dictionary<Tuple<int, int, int>, int>();
            // Perform BFS on each low point, searching for point larger than the previous point but not equal to 9, then map the point to the count
            foreach (var point in lowPoints)
            {
                var count = 1;
                var queue = new Queue<Tuple<int, int, int>>();
                queue.Enqueue(point);
                var visited = new HashSet<Tuple<int, int, int>>();
                visited.Add(point);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    var up = new Tuple<int, int>(current.Item1 - 1, current.Item2);
                    var down = new Tuple<int, int>(current.Item1 + 1, current.Item2);
                    var left = new Tuple<int, int>(current.Item1, current.Item2 - 1);
                    var right = new Tuple<int, int>(current.Item1, current.Item2 + 1);

                    if (IsValid(width, height, up.Item1, up.Item2) && input[up.Item1][up.Item2] > current.Item3 && input[up.Item1][up.Item2] != 9)
                    {
                        var upPoint = new Tuple<int, int, int>(up.Item1, up.Item2, input[up.Item1][up.Item2]);
                        if (!visited.Contains(upPoint))
                        {
                            queue.Enqueue(upPoint);
                            visited.Add(upPoint);
                            count++;
                        }
                    }
                    if (IsValid(width, height, down.Item1, down.Item2) && input[down.Item1][down.Item2] > current.Item3 && input[down.Item1][down.Item2] != 9)
                    {
                        var downPoint = new Tuple<int, int, int>(down.Item1, down.Item2, input[down.Item1][down.Item2]);
                        if (!visited.Contains(downPoint))
                        {
                            queue.Enqueue(downPoint);
                            visited.Add(downPoint);
                            count++;
                        }   
                    }
                    if (IsValid(width, height, left.Item1, left.Item2) && input[left.Item1][left.Item2] > current.Item3 && input[left.Item1][left.Item2] != 9)
                    {
                        var leftPoint = new Tuple<int, int, int>(left.Item1, left.Item2, input[left.Item1][left.Item2]);
                        if (!visited.Contains(leftPoint))
                        {
                            queue.Enqueue(leftPoint);
                            visited.Add(leftPoint);
                            count++;
                        }
                    }
                    if (IsValid(width, height, right.Item1, right.Item2) && input[right.Item1][right.Item2] > current.Item3 && input[right.Item1][right.Item2] != 9)
                    {
                        var rightPoint = new Tuple<int, int, int>(right.Item1, right.Item2, input[right.Item1][right.Item2]);
                        if (!visited.Contains(rightPoint))
                        {
                            queue.Enqueue(rightPoint);
                            visited.Add(rightPoint);
                            count++;
                        }
                    }
                }
                basinSize.Add(point, count);
            }

            // Find the top 3 points with the largest basin size
            var top3 = basinSize.OrderByDescending(x => x.Value).Take(3).ToList();

            var result = top3.Select(x => x.Value)
                .Aggregate(1, (x, y) => x * y);

            Console.WriteLine(result);
        }

        private static bool IsValid(int width, int height, int i, int j)
        {
            if (i < 0 || i >= height) return false;
            if (j < 0 || j >= width) return false;
            return true;
        }
    }
}