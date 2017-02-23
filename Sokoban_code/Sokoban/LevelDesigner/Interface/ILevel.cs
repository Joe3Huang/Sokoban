using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesigner
{
    public interface ILevel
    {
        void Level(int width, int height);
        void SetLevelName(string name);
        int GetLevelWidth();
        int GetLevelHeight();
        void AddGridBlock(Parts block, int gridX, int gridY);
        void AddMoveablePlayer(Parts player, int gridX, int gridY);
        string GetBlockAtIndex(int gridX, int gridY);
        string GetMoveableAtIndex(int gridX, int gridY);
        void SaveMe(string name);
        string Load(string path);
        string ToString(); //new method to convert GridIndex to string
        string AddGridItem(Parts symbol, int gridX, int gridY);
        string debug();
    }
}
