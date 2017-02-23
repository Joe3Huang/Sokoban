using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filer
{
    public interface ILoader
    {
        string Load(string fileName);
    }
}
