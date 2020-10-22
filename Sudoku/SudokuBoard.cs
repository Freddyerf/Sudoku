using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sudoku
{
    class SudokuBoard
    {
        private int[][] board;
        private int dimension = 9;
        public SudokuBoard()
        {
            string[] lines = File.ReadAllLines(GetRandomFile());
            board = new int[9][];
            int i = 0; 
            foreach (var line in lines)
            {
                if (!line.Equals(String.Empty))
                {
                    board[i] = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                }
                i++;
            }

        }

        public string GetRandomFile()
        {
            var rand = new Random();
            var files = Directory.GetFiles("Data", "*.txt");
            return files[rand.Next(files.Length)];
        } 

        public bool SetCell(int row, int col, int value)
        {
            if (row > board.Length) return false;
            if (col > board[row].Length) return false;
            if (value > 9 || value < 1) return false;
            if (!board[row][col].Equals(0)) return false;

            board[row][col] = value;
            return true;
        }

        public bool Verify()
        {
            for (int i = 0; i < dimension; i++)
            {
                var rows = new HashSet<int>();
                var cols = new HashSet<int>();
                var box = new HashSet<int>();
                for (int j = 0; j < dimension; j++)
                {
                    // If there are empty cells is not complete
                    if (board[i][j].Equals(0)) return false;

                    // If there are duplicates in row is invalid
                    if (!rows.Add(board[i][j])) return false;

                    // If there are duplicates in col is invalid
                    if (!cols.Add(board[j][i])) return false;

                    // Boxes in the board
                    int vertBoxOrder = 3 * (i / 3);
                    int horzBoxOrder = j / 3;
                    int boxNo = vertBoxOrder + horzBoxOrder;

                    // Cells in the Box
                    int vertCellOrder = 3 * (i % 3);
                    int horzCellOrder = j % 3;
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
                if (i % 3 == 0) sb.Append("\n");
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (j % 3 == 0) sb.Append(" ");
                    string pos = board[i][j] == 0 ? "_" : board[i][j].ToString();
                    
                    sb.Append(pos + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
