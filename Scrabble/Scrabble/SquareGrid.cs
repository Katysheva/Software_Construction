using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Scrabble
{
   public  class SquareGrid
    {
        public ObservableCollection<ObservableCollection<Cell>> Rows { get; set; }

        public SquareGrid(int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Cell>>();
            for (int i = 0; i < size; i++)
            {
                var row = new ObservableCollection<Cell>();
                for (int j = 0; j < size; j++)
                {
                    var cell = new Cell(new Letter('A', 1));
                    row.Add(cell);
                }
                Rows.Add(row);
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows.Count)
                    throw new ArgumentOutOfRangeException("Invalid row index");
                if (col < 0 || col >= Rows.Count)
                    throw new ArgumentOutOfRangeException("Invalid column index");
                return Rows[row][col];
            }
        }
    }
}
