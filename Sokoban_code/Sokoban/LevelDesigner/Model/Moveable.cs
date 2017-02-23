using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesigner
{
    public class Moveable
    {
        string Character;// = '';
        public int X = 0;
        public int Y = 0;
        public Moveable(string character)
        {
            this.Character = character;
            this.X = -1;
            this.Y = -1;
        }
        public string toString()
        {
            return this.Character;
        }
        public string GetMyType()
        {
            return this.Character;
        }
    }
}
