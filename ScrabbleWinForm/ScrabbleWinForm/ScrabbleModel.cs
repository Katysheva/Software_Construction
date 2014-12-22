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
            ScoreCount();
            if (CurrentPlayer != null && Players.Contains(CurrentPlayer))
            {
                var playerIndex = Players.IndexOf(CurrentPlayer);
                playerIndex = playerIndex == Players.Count - 1 ? 0 : playerIndex + 1;
                CurrentPlayer = Players[playerIndex];
                currentCells.Clear();
            }
        }

        public void ScoreCount()
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
                    AddToCell(cell, letter);
                    CurrentPlayer.Hand.Remove(letter);
                }
            }
        }
        public void AddToCell(Cell cell, Letter letter)
        {
            currentCells.Add(cell);
            cell.Letter = letter;
            cell.IsLocked = true;
        }

        public string WordAssembly()
        {
            var isHorizontal = true;
            if (currentCells.Count >= 2)
                isHorizontal = Grid.GetRow(currentCells[0]) == Grid.GetRow(currentCells[1]);

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                var cell = isHorizontal
                    ? Grid[Grid.GetRow(currentCells[0]), i]
                    : Grid[i, Grid.GetColumn(currentCells[0])];
                if (!currentCells.Contains(cell) && cell as BusyCell != null)
                    currentCells.Add(cell);
            }

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

            return string.Join("", currentCells.Select((cell) => cell.Letter));
        }

        public bool CheckWord(string word)
        {
            if (word == "")
                throw new ArgumentException("Field is empty");
            else
            {
                using (var sr = new StreamReader("Dictionary.txt"))
                {
                    string line;
                    var isFounded = false;
                    word = word.ToLower();
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.ToLower();
                        if (line == word)
                        {
                            isFounded = true;
                            break;
                        }
                    }
                    if (!isFounded)
                        return false;

                }
            }
            return true;
        }
    }
}
