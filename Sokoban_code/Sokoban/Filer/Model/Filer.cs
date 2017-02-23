using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Windows.Form;

namespace Filer
{
    public class Filer: IFiler //ILoader, ISaver//, IChecker
    {
        protected ILoader Loader;
        protected ISaver Saver;
        public IConverter Converter; 
        //protected IChecker Checker; 
        public Filer(ILoader loader, ISaver saver, IConverter converter)//, IChecker checker) 
        {
            Loader = loader;
            Saver = saver;
            Converter = converter;
            //Checker = checker;
        }       

        public string Load(string filename)
        {
            // sorry – you gotta do this
            string compressed =  Loader.Load(filename);
            Converter.Expand(compressed);
            string expanded = Converter.Expanded;
            return expanded;
        }
        public void Save(string filename, IFileable callMeBackforDetails)
        {
            // sorry – you gotta do this
     
            string txt = "";
            int column = callMeBackforDetails.GetColumnCount();
            int row = callMeBackforDetails.GetRowCount();

            // whatIsAs.WhatsAt(row, column);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    //txt += Convert.ToString(callMeBackforDetails.WhatsAt(r, c));
                    txt += callMeBackforDetails.WhatsAt(r, c).ToString();
                    if (c == (column - 1))
                    {
                        txt += "\n";
                    }
                }
            }
            this.Converter.Compress(txt);
            string compressedLevel = this.Converter.Compressed;
            Saver.Save(filename, compressedLevel);
        }
        
    }
}
