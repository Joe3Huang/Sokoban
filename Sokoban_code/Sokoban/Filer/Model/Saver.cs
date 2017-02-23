using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filer
{
    public class Saver : ISaver
    {
        public void Save(string filename, string compressedLevel)
        {
            //throw new NotImplementedException();     
            // System.IO.File.WriteAllText(filename,compressedLevel);
            string path = System.IO.Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.MyDoc‌​uments), "Sokoban");
            if (Directory.Exists(path))
            {

            }
            else
            {
                Directory.CreateDirectory(path);
            }
            string filePath = @path + "/" + filename + ".txt";
         //   if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, compressedLevel);
            }

        }
    }
}
