using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScrabbleWinForm
{
    public abstract class Cell : NotifyBase
    {
        private Letter letter;
        public Guid Id { get; set; }
        public Letter Letter
        {
            get { return letter; }
            set
            {
                letter = value;
                OnPropertyChanged("Letter");
            }
        }
        private bool isLocked;

        public bool IsLocked
        {
            get { return isLocked; }
            set
            {
                isLocked = value;
                OnPropertyChanged("IsLocked");
            }
        }

        private int wordFactor;

        public int WordFactor
        {
            get { return wordFactor; }
            set
            {
                wordFactor = value;
                OnPropertyChanged("WordFactor");
            }
        }
        private int factor;

        public int Factor
        {
            get { return factor; }
            set { factor = value; 
                OnPropertyChanged("Factor");}
        }
        

        public bool IsStart { get; set; }
        
        public Cell(Letter letter)
            : this()
        {
            Letter = letter;
        }

        public Cell() 
        {
            Factor = 1;
            WordFactor = 1;
            IsStart = false;
            Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
