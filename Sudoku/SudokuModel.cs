using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku
{
    class SudokuModel
    {
        public SudokuBoard Board { get; set; }

        public SudokuModel()
        {
            string[] lines = File.ReadAllLines(GetRandomFile());
            var values = new int[9][];
            int i = 0;
            foreach (var line in lines)
            {
                if (!line.Equals(String.Empty))
                {
                    values[i] = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                }
                i++;
            }

            Board = new SudokuBoard(values);

        }

        public string GetRandomFile()
        {
            var rand = new Random();
            var files = Directory.GetFiles("Data", "*.txt");
            return files[rand.Next(files.Length)];
        }

        public bool SetCell(int row, int col, int value)
        {
            if (row > Board.Values.Length) return false;
            if (col > Board.Values[row].Length) return false;
            if (value > 9 || value < 1) return false;
            if (!Board.Values[row][col].Equals(0)) return false;

            Board.Values[row][col] = value;
            return true;
        }

        public bool ClearCell(int row, int col)
        {
            if (row > Board.Values.Length) return false;
            if (col > Board.Values[row].Length) return false;
            if (Board.Starter[row][col].Equals(0)) return false;

            Board.Values[row][col] = 0;
            return true;
        }

        public bool Verify()
        {
            for (int i = 0; i < Board.Dimension; i++)
            {
                var rows = new HashSet<int>();
                var cols = new HashSet<int>();
                var box = new HashSet<int>();
                for (int j = 0; j < Board.Dimension; j++)
                {
                    // If there are empty cells is not complete
                    if (Board.Values[i][j].Equals(0)) return false;

                    // If there are duplicates in row is invalid
                    if (!rows.Add(Board.Values[i][j])) return false;

                    // If there are duplicates in col is invalid
                    if (!cols.Add(Board.Values[j][i])) return false;

                    // Boxes in the board
                    int vertBoxOrder = 3 * (i / 3);
                    int horzBoxOrder = j / 3;
                    int boxNo = vertBoxOrder + horzBoxOrder;

                    // Cells in the Box
                    int vertCellOrder = 3 * (i % 3);
                    int horzCellOrder = j % 3;
                    int cellNo = vertCellOrder + horzCellOrder;

                    // If there are duplicates in box is invalid
                    if (!box.Add(Board.Values[boxNo][cellNo])) return false;

                }
            }

            return true;
        }

        public void ProcessCommand(string command, string[] input)
        {
            switch (command)
            {
                // TODO: handle bad imput after command
                case "ADD":
                case "A":
                    SetCell(int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]));
                    break;
                case "DISPLAY":
                case "D":
                    Console.WriteLine(Board);
                    break;
                case "QUIT":
                case "Q":
                    Environment.Exit(0);
                    break;
                case "REMOVE":
                case "R":
                    ClearCell(int.Parse(input[1]), int.Parse(input[2]));
                    break;
                case "VERIFY":
                case "V":
                    Console.WriteLine(Verify() ? "Completed correctly" : "Incomplete or incorrect");
                    break;

                default:
                    string help = "a|add r c x: Add number x to (r,c)\n" +
                            "d|display: Display board\n" +
                            "h|help: Print this help message\n" +
                            "q|quit: Exit game\n" +
                            "r|remove r c: Remove number from (r,c)\n" +
                            "v|verify: Verify board correctness\n";
                    Console.WriteLine(help);
                    break;
            }
        }
    }
}
