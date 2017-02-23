using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filer
{
    public interface ISaver
    {
        void Save(string filename, string compressedLevel);
    }
}
