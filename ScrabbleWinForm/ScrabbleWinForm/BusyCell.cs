using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleWinForm
{
    public class BusyCell : Cell
    {
        public BusyCell()
            : base() {}

        public BusyCell(Letter letter)
            : base(letter){}
    }
}
