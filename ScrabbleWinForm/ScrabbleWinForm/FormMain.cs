using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrabbleWinForm
{
    public partial class FormMain : Form
    {
        private ScrabbleController scrabbleController;

        private Size size;
        private int gapSize;
        private Point startPoint;
        private Pen cellBorderPen;


        Dictionary<int, Brush> factorBrushes = new Dictionary<int, Brush>()
        {
            {1, Brushes.SeaGreen},
            {2, Brushes.DarkTurquoise},
            {3, Brushes.Blue},
        };
        Dictionary<int, Brush> wordFactorBrushes = new Dictionary<int, Brush>()
        {
            {1, Brushes.SeaGreen},
            {2, Brushes.HotPink},
            {3, Brushes.Crimson},
        };

        Bitmap gridBmp;
        Graphics gridGraphic;
        Bitmap lettersBmp;
        Graphics lettersGraphic;


        public FormMain()
        {
            InitializeComponent();
            cellBorderPen = new Pen(Color.Black, 1);
            size = new System.Drawing.Size(40, 40);
            gapSize = 2;
            startPoint = new Point(0, 0);

            gridBmp = new Bitmap(canvas.Width, canvas.Height);
            gridGraphic = Graphics.FromImage(gridBmp);

            lettersBmp = new Bitmap(pictureBoxLetters.Width, pictureBoxLetters.Height);
            lettersGraphic = Graphics.FromImage(lettersBmp);
        }

        public void DrawGrid(SquareGrid grid)
        {
            var point = startPoint;
            var dx = size.Width + gapSize;
            var dy = size.Height + gapSize;
            gridGraphic.Clear(Color.White);

            var font = SystemFonts.MessageBoxFont;
            Brush brush;

            foreach (var row in grid.Rows)
            {
                foreach (var cell in row)
                {
                    if (cell.IsStart)
                        brush = Brushes.OrangeRed;
                    else if (cell.WordFactor > 1)
                        brush = wordFactorBrushes[cell.WordFactor];
                    else
                        brush = factorBrushes[cell.Factor];
                    
                    var rect = new Rectangle(point, size);
                    gridGraphic.FillRectangle(brush, rect);
                    if (cell.Letter != null)
                    {
                        gridGraphic.FillRectangle(Brushes.BlanchedAlmond, rect);
                        gridGraphic.DrawString(cell.Letter.ToString(), font, Brushes.Black, rect);

                    }
                    gridGraphic.DrawRectangle(cellBorderPen, rect);
                    point.X += dx;
                }
                point.X = 0;
                point.Y += dy;
            }
            canvas.Image = gridBmp;
        }

        

        public void DrawLetters(List<Letter> letters, Letter currentLetter)
        {
            var point = startPoint;
            var dx = size.Width + gapSize;

            lettersGraphic.Clear(Color.White);

            var font = SystemFonts.MessageBoxFont;
            foreach (var letter in letters)
            {
                var rect = new Rectangle(point, size);
                if(letter == currentLetter)
                    lettersGraphic.FillRectangle(Brushes.BlanchedAlmond, rect);

                lettersGraphic.DrawRectangle(cellBorderPen, rect);


                lettersGraphic.DrawString(letter.ToString(), font, Brushes.Black, rect);
                point.X += dx;
            }
            pictureBoxLetters.Image = lettersBmp;


        }


        private void GetCell(Point pointOfClick)
        {
            var col = pointOfClick.X / (size.Width + gapSize);
            var row = pointOfClick.Y / (size.Height + gapSize);
            //return grid[row, col];
        }

        internal void SetController(IControllerBase controller)
        {
            var newController = controller as ScrabbleController;
            if (newController != null)
                this.scrabbleController = newController;
        }

        public string PlayerInfo
        {
            set { labelPlayerInfo.Text = value; }
        }

        private void pictureBoxLetters_MouseDown(object sender, MouseEventArgs e)
        {
            var index = e.X / (size.Width + gapSize);
            scrabbleController.SelectLetter(index);
        }

        private void buttonNextPlayer_Click(object sender, EventArgs e)
        {
            scrabbleController.NextPlayer();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            var col = e.X / (size.Width + gapSize);
            var row = e.Y / (size.Height + gapSize);
            scrabbleController.SelectCell(col, row);
        }
    }
}
