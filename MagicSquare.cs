using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{
    class MagicSquare
    {
        public MagicSquare(int size)
        {
            if (size < 1 || size % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(size), "only positive odd integers are acceptable");

            Square = new int[size, size];

            var pos = (0, size / 2);
            Square[pos.Item1, pos.Item2] = 1;

            for (int i = 2; i < size * size; ++i)
            {
                var possible = (
                    pos.Item1 == 0 ? size - 1 : pos.Item1 - 1,
                    (pos.Item2 + 1) % size
                );
                if (Square[possible.Item1, possible.Item2] == 0) pos = possible;
                else pos.Item1 += 1;
                Square[pos.Item1, pos.Item2] = i;
            }
        }

        public int[,] Square { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Square.GetLength(0); i++)
            {
                for (int j = 0; j < Square.GetLength(1); ++j)
                {
                    result.Append($"{Square[i, j]}\t");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
