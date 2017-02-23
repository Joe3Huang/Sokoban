using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum Direction { up, Down, Left, Right };

    public interface IGame
    {
        void Move(Direction moceDirection);
        int getMoveCount();
        void Undo();
        void Restart();
        bool isFinished();
        void Load(string newLevel);
    }
}
