using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class SudokuModel
    {
        public SudokuBoard Board { get; set; }

        public SudokuModel(SudokuBoard board)
        {
            this.Board = board;

        }


    }
}
