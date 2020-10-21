using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sudoku
{
    class SudokuBoard
    {
        private int[][] board;
        public SudokuBoard()
        {
            // TODO: Generate random board or passed in as parameter

            /*
             * Solution:
             * { 4, 3, 1, 2 }
             * { 2, 1, 3, 4 }
             * { 3, 2, 4, 1 }
             * { 1, 4, 2, 3 }
             */  
            board = new int[][]{
                new int[] { 0, 3, 0, 0 },
                new int[] { 2, 1, 3, 0 },
                new int[] { 0, 2, 4, 1 },
                new int[] { 1, 0, 0, 0 }
                };

        }

        public bool SetCell(int row, int col, int value)
        {
            if (row > board.Length) return false;
            if (col > board[row].Length) return false;
            if (value > 4 || value < 1) return false;
            if (!board[row][col].Equals(0)) return false;

            board[row][col] = value;
            return true;
        }

        public bool Verify()
        {
            for (int i = 0; i < 4; i++)
            {
                var rows = new HashSet<int>();
                var cols = new HashSet<int>();
                var box = new HashSet<int>();
                for (int j = 0; j < 4; j++)
                {
                    // If there are empty cells is not complete
                    if (board[i][j].Equals(0)) return false;

                    // If there are duplicates in row is invalid
                    if (!rows.Add(board[i][j])) return false;

                    // If there are duplicates in col is invalid
                    if (!cols.Add(board[j][i])) return false;

                    // Boxes in the board
                    int vertBoxOrder = 2 * (i / 2);
                    int horzBoxOrder = j / 2;
                    int boxNo = vertBoxOrder + horzBoxOrder;

                    // Cells in the Box
                    int vertCellOrder = 2 * (i % 2);
                    int horzCellOrder = j % 2;
                    int cellNo = vertCellOrder + horzCellOrder;

                    // If there are duplicates in box is invalid
                    if (!box.Add(board[boxNo][cellNo])) return false;

                }
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    string pos = board[i][j] == 0 ? "_" : board[i][j].ToString();
                    sb.Append(pos + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
