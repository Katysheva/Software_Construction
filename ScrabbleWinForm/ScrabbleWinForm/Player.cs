using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleWinForm
{
    public class Player : NotifyBase
    {

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private int score;

        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        private ObservableCollection<Letter> hand;

        public ObservableCollection<Letter> Hand
        {
            get { return hand; }
            set
            {
                hand = value;
                OnPropertyChanged("Hand");
            }
        }

        public Player(string name)
        {
            this.Name = name;
            Hand = new ObservableCollection<Letter>();
        }

        public override string ToString()
        {
            return string.Format("{0} : {1} очка(ов)", Name, Score);
        }
    }
}
