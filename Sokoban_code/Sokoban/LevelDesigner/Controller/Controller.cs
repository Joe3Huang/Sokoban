using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesigner
{
    public class Controller
    {
        protected Form1 View;
        protected ILevel TheLevel;

        public Controller(Form1 view, ILevel theLevel)
        {
            View = view;
            TheLevel = theLevel;
        }

        public void SetLevel(int width, int height)
        {
            TheLevel.Level(width, height);
        }

        public string AddItemToGird(Parts symbol, int gridX, int gridY)
        {
            return TheLevel.AddGridItem(symbol, gridX, gridY);
        }

        public void Save(string name)
        {
            TheLevel.SaveMe(name);
            //return "OK";
        }

        public void Load(string path)
        {
            string s = TheLevel.Load(path);
            string[] sArray = s.Split('\n');
            int width = 0;
            int height = 0;
            sArray = sArray.Take(sArray.Count() - 1).ToArray();
            if (sArray.Length > 0)
            {
                width = sArray[0].Length;
                height = sArray.Length;
            }
            SetLevel(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    TheLevel.AddGridItem((Parts)sArray[y][x], x, y);
                }
            }
            View.GridOfButton(width, height);
            View.DisplayGame(sArray);
            View.SetClicks();
        }
        public void SetLevelName(string n)
        {
            TheLevel.SetLevelName(n);
        }
        public void go()
        {
           /// TheLevel.debug();
           // View.debugString( TheLevel.debug());
            //View.debugValueLabel4(TheLevel.ToString());
        }
    }
}
