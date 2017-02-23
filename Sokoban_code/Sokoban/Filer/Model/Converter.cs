using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filer
{
    public class Converter : IConverter
    {
        protected string compressed;
        protected string expanded;

        public string Compressed
        {
            get
            {
                return compressed;
            }
        }

        public string Expanded
        {
            get
            {
                return expanded;
            }
        }

        public void Compress(string uncompressedLevel)
        {           
            uncompressedLevel = uncompressedLevel.TrimEnd(' ');
            string pattern = @"\s+\n";
            Regex spaceBeforeNewLine = new Regex(pattern);
            uncompressedLevel = Regex.Replace(uncompressedLevel, pattern,"\n");
            compressed = CompressMultiple.ReplaceRepeated(uncompressedLevel);
            compressed = compressed.Replace(" ", "-");
            compressed = compressed.Replace("\n", "|");
                    
        }
        public static class CompressMultiple
        {
            public static string ReplaceRepeated(string s)
            {
                return Regex.Replace(s, @"(.)\1+", delegate (Match match)
                {
                    string found = match.ToString();
                    return found.Length.ToString() + found.First();
                });
            }
        }
        
        public void Expand(string uncompressedLevel)
        {
            string pattern = @"\d+.";
            uncompressedLevel = uncompressedLevel.Replace("-", " ");
            uncompressedLevel = uncompressedLevel.Replace("|", "\n");
            expanded = ExpandNubmer.ReplaceNumber(uncompressedLevel, pattern);

        }
        public static class ExpandNubmer
        {
            public static string ReplaceNumber(string s, string pattern)
            {
                return Regex.Replace(s, pattern, delegate (Match match)
                {
                    string found = match.ToString();
                    char charToRepeat = found.Last();
                    string foundNumber = found.Remove(found.Length - 1);
                    int numberOfChar = Convert.ToInt16(foundNumber);
                    string replacedNumber = "";
                    for (int i = 1; i <= numberOfChar; i++)
                    {
                        replacedNumber += charToRepeat;
                    }
                    return replacedNumber;
                });
            }
        }
    }
}
