using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrabbleWinForm
{
    public class ScrabbleModel
    {
        public SquareGrid Grid { get; set; }
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public Letter CurrentLetter { get; set; }
        public List<Letter> Set { get; set; }

        private List<Cell> currentCells;

        public ScrabbleModel()
        {
            InitMap();
            FillSet();
            CreatePlayers();
            DealTheLetters();
            CurrentPlayer = Players[0];
            currentCells = new List<Cell>();
        }
        public void InitMap()
        {
            using (var sr = new StreamReader("Map.txt"))
            {
                string line;
                Grid = new SquareGrid(15);
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split();
                    for (int j = 0; j < items.Length; j++)
                    {
                        var item = items[j];
                        var freeCell = new FreeCell();
                        Grid.Rows[i][j] = freeCell;

                        if (item == "*")
                            freeCell.IsStart = true;
                        else if (item[item.Length - 1] == 'w')
                            freeCell.WordFactor = int.Parse(item.Trim('w'));
                        else
                            freeCell.Factor = int.Parse(item);
                    }
                    i++;
                }
            }
        }
        private void FillSet()
        {
            Set = new List<Letter>();
            using (var sr = new StreamReader("AlphaSet.txt"))
            {
                sr.ReadLine();//пропуск первой строки
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split();
                    var count = int.Parse(data[1]);
                    for (int i = 0; i < count; i++)
                    {
                        var letter = new Letter(data[0][0], int.Parse(data[2]));
                        Set.Add(letter);
                    }
                }
            }
        }
        public void CreatePlayers()
        {
            Players = new List<Player>();
            for (int i = 0; i < 2; i++)
            {
                Players.Add(new Player(string.Format("Player{0}", i + 1)));
            }
        }

        public void DealTheLetters()
        {
            if (Set != null)
            {
                var rd = new Random();
                foreach (var player in Players)
                {
                    for (int i = player.Hand.Count; i < 7; i++)
                    {
                        if (Set.Count != 0)
                        {
                            var vacantIndex = rd.Next(Set.Count);
                            player.Hand.Add(Set[vacantIndex]);
                            Set.RemoveAt(vacantIndex);
                        }
                    }
                }
            }
        }

        internal void SelectLetter(int index)
        {
            CurrentLetter = CurrentPlayer.Hand[index];
        }

        public void NextPlayer()
        {

            if (CurrentPlayer != null && Players.Contains(CurrentPlayer))
            {
                foreach (var cell in currentCells)
                {
                    CurrentPlayer.Score += cell.Letter.Points * cell.Factor;
                }
                foreach (var cell in currentCells)
                {
                    CurrentPlayer.Score *= cell.WordFactor;
                }

                var playerIndex = Players.IndexOf(CurrentPlayer);
                playerIndex = playerIndex == Players.Count - 1 ? 0 : playerIndex + 1;
                CurrentPlayer = Players[playerIndex];


                currentCells.Clear();
            }
        }


        internal void TryReceive(Letter letter, Cell cell)
        {
            if (!cell.IsLocked)
            {

                var allowRow = true;
                var allowCol = true;
                foreach (var c in currentCells)
                {
                    if (c == cell)
                    {
                        allowRow = false;
                        allowCol = false;
                        break;
                    }
                    if (Grid.GetRow(c) != Grid.GetRow(cell))
                        allowRow = false;
                    if (Grid.GetColumn(c) != Grid.GetColumn(cell))
                        allowCol = false;
                }
                if (allowCol || allowRow)
                {
                    currentCells.Add(cell);
                    cell.Letter = letter;
                    cell.IsLocked = true;
                    CurrentPlayer.Hand.Remove(letter);
                }
            }


        }

        internal void IntermediateCount()
        {
            var isHorizontal = true;
            if (currentCells.Count >= 2)
                isHorizontal = Grid.GetRow(currentCells[0]) == Grid.GetRow(currentCells[1]);

            currentCells.Sort(new Comparison<Cell>(
                (cell1, cell2) => 
                {
                    int result = 0;
                    if (isHorizontal)
                        result = Grid.GetColumn(cell1).CompareTo(Grid.GetColumn(cell2));
                    else
                        result = Grid.GetRow(cell1).CompareTo(Grid.GetRow(cell2));
                    return result;
                }
                ));

            var word = string.Join("", currentCells.Select((cell) => cell.Letter));
            CheckWord(word);

            DealTheLetters();
        }
        public void CheckWord(string word)
        {
            using (var sr = new StreamReader("Dictionary.txt"))
            {
                string line;
                int i = 0;
                var isFounded = false;
                while ((line = sr.ReadLine()) == word || (line = sr.ReadLine()) != null)
                {
                    word = word.ToLower();
                    line = line.ToLower();
                    if (line == word)
                    {
                        isFounded = true;
                        MessageBox.Show(line);
                    }
                    else
                        i++;
                }
                if (!isFounded)
                    MessageBox.Show("Word is incorrect!");
            }
        }
    }
}
