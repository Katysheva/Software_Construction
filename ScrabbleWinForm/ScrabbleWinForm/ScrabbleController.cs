using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleWinForm
{
    class ScrabbleController : IControllerBase
    {
        private ScrabbleModel model;
        private FormMain view;

        public ScrabbleController(ScrabbleModel model, FormMain view)
        {
            this.model = model;
            this.view = view;
            view.SetController(this);
        }

        public void RenderView()
        {

            if (view != null)
            {
                view.DrawGrid(model.Grid);
            }
            RenderPlayer();
        }

        private void RenderPlayer()
        {
            if (view != null)
            {
                if (model.CurrentPlayer != null)
                {
                    view.PlayerInfo = model.CurrentPlayer.ToString();
                    view.DrawLetters(model.CurrentPlayer.Hand.ToList(), model.CurrentLetter);
                }
                else
                    view.PlayerInfo = "";
            }
        }

        internal void SelectLetter(int index)
        {
            if(model.CurrentPlayer!= null && model.CurrentPlayer.Hand.Count > index)
            {
                model.SelectLetter(index);
                RenderPlayer();
            }
        }
        public void NextPlayer()
        {
            model.IntermediateCount();
            model.NextPlayer();
            RenderPlayer();
        }

        internal void SelectCell(int col, int row)
        {
            var cell = model.Grid[row, col];
            if (model.CurrentLetter != null)
            {
                model.TryReceive(model.CurrentLetter, cell);
                RenderView();
            }
        }
    }
}
