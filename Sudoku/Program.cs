using System;
using System.Collections.Specialized;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new SudokuBoard();

            while (true)
            {
                Console.WriteLine(sudoku);

                Console.WriteLine("Enter row");
                int row = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter column");
                int col = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Value");
                int val = int.Parse(Console.ReadLine());

                sudoku.SetCell(row, col, val);
            }
            
            
        }
    }
}
