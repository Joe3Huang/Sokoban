using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filer
{
    public interface IChecker
    {
        bool? PreExpandingCheck(string input);
        bool? PreCompressingCheck(string input);
    }
}
