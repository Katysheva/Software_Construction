using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scrabble
{
     public class Cell
    {
        public Letter Letter { get; set; }
        public Cell(Letter letter) 
            : base()
        {
            Letter = letter;
        }

        public Cell() { }
    }
}
