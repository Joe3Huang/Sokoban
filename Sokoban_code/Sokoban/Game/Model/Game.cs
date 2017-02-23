using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game : IGame, Filer.IFileable
    {
        public string[] GameLevel = new string[] { };
        public string[] PlayingLevel = new string[] { };
        public List<Direction> steps = new List<Direction>();
        public int GetRowCallCount = 0;
        public int GetColumnCallCount = 0;
        public int PlayerRow = 0;
        public int PlayerColumn = 0;
        public Filer.Parts WhatsAtCallCount = 0;
        public List<int> rowsChecked = new List<int>();
        public List<int> columnsChecked = new List<int>();
        public bool Initialization = false;
        public bool InitializeGame()
        {
            this.rowsChecked.Clear();
            this.columnsChecked.Clear();
            this.steps.Clear();
            this.GetRowCallCount = 0;
            this.GetColumnCallCount = 0;
            this.PlayerRow = 0;
            this.PlayerColumn = 0;
            for (int i = 0; i < GameLevel.Length; i++)
            {
                PlayingLevel[i] = GameLevel[i];
            }
            if (PlayingLevel.Length > 0)
            {
                this.GetColumnCallCount = PlayingLevel[0].Length;
                this.GetRowCallCount = PlayingLevel.Length;
            }
            this.getPlayerPosition();
            if (PlayingLevel.Length > 0)
            {
                return true;
            }
            return false;
        }

        public void Move(Direction moveDirection)
        {
            int targetRow = PlayerRow;
            int targetColumn = PlayerColumn;
            int targetRow2 = PlayerRow;
            int targetColumn2 = PlayerColumn;
            Filer.Parts targetParts;
            Filer.Parts targetParts2;
            targetRow = DirectionRowCount(moveDirection, PlayerRow);
            targetColumn = DirectionColumnCount(moveDirection,PlayerColumn);
            targetParts = (Filer.Parts)this.WhatsAt(targetRow, targetColumn);

            if (targetParts == Filer.Parts.Block)
            {
                targetRow2 = DirectionRowCount(moveDirection, targetRow);
                targetColumn2 = DirectionColumnCount(moveDirection, targetColumn);
                targetParts2 = (Filer.Parts)this.WhatsAt(targetRow2, targetColumn2);
                if (targetParts2 == Filer.Parts.Goal)
                {
                    ChangeCharInPlayingLevel((char)Filer.Parts.BlockOnGoal, targetRow2, targetColumn2);
                    ChangeCharInPlayingLevel((char)Filer.Parts.Player, targetRow, targetColumn);
                    ChengeThePlayerGird();
                    UpdatePlayerPosition(targetRow, targetColumn);
                }
                else if (targetParts2 == Filer.Parts.Wall)
                {

                }
                else
                {
                    ChangeCharInPlayingLevel((char)Filer.Parts.Block, targetRow2, targetColumn2);
                    ChangeCharInPlayingLevel((char)Filer.Parts.Player, targetRow, targetColumn);
                    ChengeThePlayerGird();
                    UpdatePlayerPosition(targetRow, targetColumn);
                }
            }
            else if (targetParts == Filer.Parts.BlockOnGoal)
            {
                targetRow2 = DirectionRowCount(moveDirection, targetRow);
                targetColumn2 = DirectionColumnCount(moveDirection, targetColumn);
                targetParts2 = (Filer.Parts)this.WhatsAt(targetRow2, targetColumn2);
                if (targetParts2 == Filer.Parts.Goal)
                {
                    ChangeCharInPlayingLevel((char)Filer.Parts.BlockOnGoal, targetRow2, targetColumn2);
                    ChangeCharInPlayingLevel((char)Filer.Parts.PlayerOnGoal, targetRow, targetColumn);
                    ChengeThePlayerGird();
                    UpdatePlayerPosition(targetRow, targetColumn);
                }
                else if (targetParts2 == Filer.Parts.Wall)
                {

                }
                else if (targetParts2 == Filer.Parts.Block)
                {

                }
                else
                {
                    ChangeCharInPlayingLevel((char)Filer.Parts.Block, targetRow2, targetColumn2);
                    ChangeCharInPlayingLevel((char)Filer.Parts.PlayerOnGoal, targetRow, targetColumn);
                    //ChangeCharInPlayingLevel(' ', PlayerRow, PlayerColumn);
                    ChengeThePlayerGird();
                    UpdatePlayerPosition(targetRow, targetColumn);
                }

            }
            else if (targetParts == Filer.Parts.Goal)
            {
                ChangeCharInPlayingLevel((char)Filer.Parts.PlayerOnGoal, targetRow, targetColumn);
                ChengeThePlayerGird();
                UpdatePlayerPosition(targetRow, targetColumn);
            }
            else if (targetParts == Filer.Parts.Wall)
            {

            }
            else //if (targetParts == Filer.Parts.Empty1)
            {
                ChangeCharInPlayingLevel((char)Filer.Parts.Player, targetRow, targetColumn);
                ChengeThePlayerGird();
                UpdatePlayerPosition(targetRow, targetColumn);
            }
        }

        private void UpdatePlayerPosition(int row, int column)
        {
            PlayerRow = row;
            PlayerColumn = column;
        } 

        public int DirectionRowCount(Direction moveDirection, int row)
        {
            int r = row;
            if (moveDirection == Direction.up)
            {
                if (rowsChecked.Exists(x => x == row - 1))
                {
                    r =  row - 1;
                }
            }
            else if (moveDirection == Direction.Down)
            {
                if (rowsChecked.Exists(x => x == row + 1))
                {
                    r = row + 1;
                }
            }
            return r;
        }

        public int DirectionColumnCount(Direction moveDirection, int column)
        {
            int c = column;

            if (moveDirection == Direction.Left)
            {
                if (columnsChecked.Exists(x => x == column - 1))
                {
                    c = column - 1;
                }
            }
            else if (moveDirection == Direction.Right)
            {
                if (columnsChecked.Exists(x => x == column + 1))
                {
                    c = column + 1;
                }
            }
            else
            {

            }
            return c;
        }

        public void ChangeCharInPlayingLevel(char symbol, int row, int Column)
        {
            if (this.PlayingLevel.Length > 0)
            {
                StringBuilder sb = new StringBuilder(this.PlayingLevel[row]);
                sb[Column] = symbol;
                this.PlayingLevel[row] = sb.ToString();
            }
        }

        public void ChengeThePlayerGird()
        {
            Filer.Parts playerGird = (Filer.Parts)this.WhatsAt(PlayerRow, PlayerColumn);
            if (playerGird == Filer.Parts.PlayerOnGoal)
            {
                ChangeCharInPlayingLevel((char)Filer.Parts.Goal, PlayerRow, PlayerColumn);
            }
            else
            {
                ChangeCharInPlayingLevel(' ', PlayerRow, PlayerColumn);
            }
        }

        public bool FirstCheckIfCanMove(Direction moveDirection)
        {
            int targetRow = PlayerRow;
            int targetColumn = PlayerColumn;
            Filer.Parts targetParts;
            targetRow = DirectionRowCount(moveDirection, PlayerRow);
            targetColumn = DirectionColumnCount(moveDirection, PlayerColumn);
            targetParts = (Filer.Parts)this.WhatsAt(targetRow, targetColumn);
            if (targetParts == Filer.Parts.Block)
            {
                if (SecondCheckIfCanMove(moveDirection, targetRow, targetColumn))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (targetParts == Filer.Parts.Wall)
            {
                return false;
            }
            else if (targetParts == Filer.Parts.Goal)
            {
                return true;
            }
            else 
            {
                return true;
            }
        }

        public bool SecondCheckIfCanMove(Direction moveDirection,int row, int column)
        {
            int targetRow = row;
            int targetColumn = column;
            Filer.Parts targetParts;
            targetRow = DirectionRowCount(moveDirection, row);
            targetColumn = DirectionColumnCount(moveDirection, column);
            targetParts = (Filer.Parts)this.WhatsAt(targetRow, targetColumn);
            if (targetParts == Filer.Parts.Block)
            {
                return false;
            }
            else if (targetParts == Filer.Parts.Wall)
            {
                return false;
            }
            else if (targetParts == Filer.Parts.Goal)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public int getMoveCount()
        {
            return steps.Count;
        }

        public void PlayTrack(Direction moveDirection)
        {
            steps.Add(moveDirection);
        }

        public void Undo()
        {
            if (steps.Count > 0)
            {
                steps.RemoveAt(steps.Count - 1);
                for (int i = 0; i < GameLevel.Length; i++)
                {
                    PlayingLevel[i] = GameLevel[i];
                }
                getPlayerPosition();
                foreach (Direction s in steps)
                {
                    this.Move(s);
                }
                
            }
        }

        public void Restart()
        {
            this.Initialization = InitializeGame();
        }


        public bool isFinished()
        {
            int boxes = 0;
            int goals = 0;        
            for (int r = 0; r < GetRowCallCount; r++)
            {
                for (int c = 0; c < GetColumnCallCount; c++)
                {
                    if ((Filer.Parts)WhatsAt(r, c) == Filer.Parts.Block)
                    {
                        boxes++;
                    }
                    if ((Filer.Parts)WhatsAt(r, c) == Filer.Parts.Goal)
                    {
                        goals++;
                    }
                }
            }
            if ((boxes == 0) && (goals == 0))
            {
                return true;
            }
            return false;
        }

        protected void getPlayerPosition()
        {
            for (int r = 0; r < GetRowCallCount; r++)
            {
                for (int c = 0; c < GetColumnCallCount; c++)
                {
                    if ((Filer.Parts)WhatsAt(r, c) == Filer.Parts.Player)
                    {
                        PlayerRow = r;
                        PlayerColumn = c;
                    }
                }
            } 
        }

        public void Load(string newLevel)
        {
            string[] sArray = newLevel.Split('\n');
            if (sArray.Count() >= 0)
            {
                sArray = sArray.Take(sArray.Count() - 1).ToArray();
                this.GameLevel = sArray;
                Array.Resize(ref PlayingLevel, GameLevel.Length);
                for (int i = 0; i < GameLevel.Length; i++)
                {
                    this.PlayingLevel[i] = GameLevel[i];
                }
                this.Initialization = InitializeGame();
            }
        }

        public char WhatsAt(int row, int column)
        {
            // this.WhatsAtCallCount++;
            char part = '\n';
            if ((row >= 0) && (column >= 0))
            {
                rowsChecked.Add(row);
                 columnsChecked.Add(column);
            // UPDATED CODE
                part = PlayingLevel[row][column];

            }
            return part;
            //return (Filer.Parts)(int)part;
        }

        public int GetColumnCount()
        {
            int count = 0;
            while (count < this.GetColumnCallCount)
            {
                count++;
            }
            return count;
        }

        public int GetRowCount()
        {
            int count = 0;
            while (count <  this.GetRowCallCount)
            {
                count++;
            }
            return count;
        }
    }
}
