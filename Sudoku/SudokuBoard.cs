using System.Text;

namespace Sudoku
{
    class SudokuBoard
    {
        public int[][] Values { get; set; }
        public int[][] Starter { get; set; }
        public int Dimension { get; set; }
        public SudokuBoard(int[][] board)
        {
            this.Starter = this.Values = board;
            this.Dimension = board.Length;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Values.Length; i++)
            {
                if (i % 3 == 0) sb.Append("\n");
                for (int j = 0; j < Values[i].Length; j++)
                {
                    if (j % 3 == 0) sb.Append(" ");
                    string pos = Values[i][j] == 0 ? "_" : Values[i][j].ToString();
                    
                    sb.Append(pos + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
