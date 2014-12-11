using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ScrabbleWinForm
{
    public class SquareGrid
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

                    var cell = new FreeCell();
                    row.Add(cell);
                }
                Rows.Add(row);
            }
        }

        public int GetRow(Cell cell)
        {
            int row = -1;
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Rows.Count; j++)
                {
                    var currCell = this[i, j];
                    if (currCell == cell)
                        row = i;
                }
            }
            return row;
        }

        public int GetColumn(Cell cell)
        {
            int col = -1;
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Rows.Count; j++)
                {
                    var currCell = this[i, j];
                    if (currCell == cell)
                        col = j;
                }
            }
            return col;
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
            set
            {
                if (row < 0 || row >= Rows.Count)
                    throw new ArgumentOutOfRangeException("Invalid row index");
                if (col < 0 || col >= Rows.Count)
                    throw new ArgumentOutOfRangeException("Invalid column index");
                Rows[row][col] = value;

            }
        }
    }
}
