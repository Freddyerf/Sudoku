using System;
using System.Collections.Specialized;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new SudokuModel();

            Console.WriteLine(sudoku.Board);
            while (true)
            {

                Console.Write("/> ");
                string[] input = Console.ReadLine().Split(" ");
                string command = input[0].ToUpper();

                sudoku.ProcessCommand(command, input);
            }
            
            
        }
    }
}
