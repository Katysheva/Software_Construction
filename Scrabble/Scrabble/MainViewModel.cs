using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Scrabble
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SquareGrid grid;

        public ObservableCollection<ObservableCollection<Cell>> Rows
        {
            get { return grid.Rows; }
            set { grid.Rows = value; OnPropertyChanged("Rows"); }
        }
        
        public MainViewModel()
        {
            grid = new SquareGrid(15);
        }
        private void OnPropertyChanged(string p)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }



    }
}
