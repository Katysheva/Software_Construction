using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    public class Letter
    {
        private char symbol;
        public Letter(char symbol, int points)
        {
            this.symbol = symbol;
            this.Points = points;
        }

        public override string ToString()
        {
            return symbol.ToString();
        }

        public int Points { get; private set; }
    }
}
