using System;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = GetSquareMatrix(-5);
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); ++j)
                {
                    Console.Write($"{square[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        static int[,] GetSquareMatrix(int n)
        {
            if (n < 1 || n % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(n), "only positive odd integers are acceptable");

            var res = new int[n, n];

            var pos = (0, n / 2);
            res[pos.Item1, pos.Item2] = 1;

            for (int i = 2; i < n * n; ++i)
            {
                var possible = (
                    pos.Item1 == 0 ? n - 1 : pos.Item1 - 1,
                    (pos.Item2 + 1) % n
                );
                if (res[possible.Item1, possible.Item2] == 0) pos = possible;
                else pos.Item1 += 1;
                res[pos.Item1, pos.Item2] = i;
            }

            return res;
        }
    }
}
