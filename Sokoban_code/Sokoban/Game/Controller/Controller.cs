using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Controller
    {
        protected Form1 View;
        protected Game TheGame;
        public Controller(Form1 view, Game theGame)
        {
            View = view;
            TheGame = theGame;
        }

        public void Load(string fileName)//Controller
        {
            Filer.Loader Loader = new Filer.Loader();
            Filer.Filer Filer = new Filer.Filer(new Filer.Loader(), new Filer.Saver(), new Filer.Converter());
            string s = Filer.Load(fileName);
            TheGame.Load(s);
            View.GridOfButton(TheGame.GetColumnCount(), TheGame.GetRowCount());
            UpdateView();
        }

        public void UpdateView()
        {
            View.DisplayGame(TheGame.PlayingLevel);
        }

        public void Move(Direction direction)
        {
            if(TheGame.Initialization)
            { 
                if (TheGame.FirstCheckIfCanMove(direction))
                {
                    TheGame.Move(direction);
                    TheGame.PlayTrack(direction);
                    this.UpdateView();
                }
            }
            if (TheGame.isFinished())
            {
                View.ShowWin("WIN!!!!");
            }
            View.ShowMoveCount(TheGame.getMoveCount());
        }
        
        public void Restart()
        {
            TheGame.Restart();
            this.UpdateView();
            View.ShowWin("Hello!!!!");
        }

        public void Undo()
        {
            TheGame.Undo();
            this.UpdateView();
            View.ShowMoveCount(TheGame.getMoveCount());
        }

        public void Save(string fileName)
        {
             Filer.Filer Filer = new Filer.Filer(new Filer.Loader(), new Filer.Saver(), new Filer.Converter());
             Filer.Save(fileName, TheGame);
        }

    }
}
