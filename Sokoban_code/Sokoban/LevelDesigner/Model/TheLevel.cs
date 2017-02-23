using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesigner
{
    public enum Parts
    {
        Wall = (int)'#',
        Empty = (int)'-',
        Player = (int)'@',
        Goal = (int)'.',
        Block = (int)'$',
        BlockOnGoal = (int)'*',
        PlayerOnGoal = (int)'+'
    }

    public class TheLevel : ILevel, Filer.IFileable
    {
        string LevelName = "";
        int Width;
        int Height;
        Filer.Filer Filer = new Filer.Filer(new Filer.Loader(), new Filer.Saver(), new Filer.Converter());
        //int debugVuale = 1;
        public string WidthTooSmallMessage = "the width is too small";
        public string HeightTooSmallMessage = "the height is too small";
        public string LevelAreaTooSmallMessage = "the area is too small";
        public string[] mapArray;

        public void Level(int width, int height)
        {
            if (width <= 2)
            {
              //  throw new ArgumentOutOfRangeException(WidthTooSmallMessage);
            }
            else if (height <= 2)
            {
               // throw new ArgumentOutOfRangeException(HeightTooSmallMessage);
            }
            else if (width * height < 15)
            {
              //  throw new ArgumentOutOfRangeException(LevelAreaTooSmallMessage);
            }
            this.Width = width;
            this.Height = height;
            Array.Resize<string>(ref mapArray, height * width);
            mapArray = mapArray.Select(i => Convert.ToString((char)Parts.Empty)).ToArray();
        }
        public void SetLevelName(string name)
        {
            this.LevelName = name;
        }
        public int GetLevelWidth()
        {
            return this.Width;
        }

        public int GetLevelHeight()
        {
            return this.Height;
        }

        public void AddGridBlock(Parts block, int gridX, int gridY)
        {
            this.mapArray[gridX + (this.Width * gridY)] = Convert.ToString((char)block);
        }

        public void AddMoveablePlayer(Parts player, int gridX, int gridY)
        {
            if (gridX > this.Width)
            {
                throw new ArgumentOutOfRangeException("X out of range");
            }
            else if (gridY > this.Height)
            {
                throw new ArgumentOutOfRangeException("Y out of range");
            }
            else
            {
                this.mapArray[gridX + (this.Width * gridY)] = Convert.ToString((char)player);
            }
        }

        public string debug()
        {
            Filer.Converter.Expand("3#@5$|5T|.2$6-3r4.|t4f");
            return Filer.Converter.Expanded;
        }

        public string GetBlockAtIndex(int gridX, int gridY)
        {
            return this.mapArray[gridX + (this.Width * gridY)];
        }

        public string GetMoveableAtIndex(int gridX, int gridY)
        {
            return this.mapArray[gridX + (this.Width * gridY)];
        }

        public void SaveMe(string name)
        {
            if (name == "")
            {
                name = this.LevelName;
            }
            Filer.Save(name, this);
            // call Save from filer model
        }

        public string Load(string path)
        {
            return Filer.Load(path);
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < this.mapArray.Length; i++)
            {
                output += this.mapArray[i];
                if ((i+1)%this.Width == 0)
                {
                 output += '\n';
                }
            }
            return output;
        }

        public string AddGridItem(Parts symbol, int gridX, int gridY)
        {
            string returnMessage = "OK";
            AddGridBlock(symbol, gridX, gridY);
            if (symbol == Parts.Wall)
            {
                returnMessage = "OK";
            }
            else if (symbol == Parts.Player)
            {
                returnMessage = this.checkIfMoreThanOnePlayer();
            }
            else if ((symbol == Parts.Goal) || (symbol == Parts.Block))
            {
                returnMessage = this.CheckIfBoxesMoreThanGoals();
            }
           // if(returnMessage == "OK")
            {
                AddGridBlock(symbol, gridX, gridY);
            }           
            return returnMessage;
        }
        private string checkIfMoreThanOnePlayer()
        {
            int i = 0;
            string message = "OK";
            foreach (string s in this.mapArray)
            {
                if (s == Convert.ToString((char)Parts.Player))
                {
                    i++;
                }
            }
            if (i > 1)
            {
                message = "Too Many players";
            }
            return message;
        }
        private string CheckIfBoxesMoreThanGoals()
        {
            int boxesCount = 0;
            int goalCount = 0;
            string message = "OK";
            foreach (string s in this.mapArray)
            {
                if (s == Convert.ToString((char)Parts.Block))
                {
                    boxesCount++;
                }
                if (s == Convert.ToString((char)Parts.Goal))
                {
                    goalCount++;
                }
            }
            if ((boxesCount > 0) || (goalCount > 0))
            {
                if((boxesCount - goalCount > 1) || (goalCount - boxesCount > 1))
                    message = "The quantities of Boxes and goals don't match";
            }
            return message;
        }
        public char WhatsAt(int row, int column)
        {
            int x = column;
            int y = row;
            return Char.Parse(mapArray[x + (this.Width * y)]);// (Parts)Enum.Parse(typeof(Parts), mapArray[x + (x * y)]);
        }
        public int GetColumnCount()
        {
            int count = 0;
            while (count < this.Width)
            {
                count++;
            }
            return count;
        }
        public int GetRowCount()
        {
            int count = 0;
            while (count < this.Height)
            {
                count++;
            }
            return count;
        }

    }
}
