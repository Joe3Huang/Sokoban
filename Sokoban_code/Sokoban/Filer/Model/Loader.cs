using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filer
{
    public class Loader : ILoader
    {
        public string Load(string fileName)
        {
            string result;
            try
            {
                result = System.IO.File.ReadAllText(fileName);
            }
            catch (FileNotFoundException )
            {
                result = "";
            }
            return result;
        }
    }
}
