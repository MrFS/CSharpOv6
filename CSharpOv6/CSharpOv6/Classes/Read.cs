using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpOv6.Classes
{
    public class Read
    {
        //Key = Ord i Håvamål - Value = Hvilken strofe ordet eksisterer i
        private Dictionary<string, string> _OrdPaStrofe = new Dictionary<string, string>();

        public Dictionary<string, int> File(string filename)
        {

            //Key = Ord i Håvamål - Value = Antall ganger ordet gjentar seg i Håvamål
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            string strofe = "";

            using (StreamReader sr = new StreamReader(filename))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();

                    if (line.Contains("Strofe"))
                    {
                        strofe = KunTall(line);
                    }

                    string[] words = line.Split(' ');

                    foreach (string word in words)
                    {

                        string lele = RemoveSpecialCharacters(word);
                        lele = lele.ToLower();
                        
                        if (strofe != string.Empty)
                        {
                            if (_OrdPaStrofe.ContainsKey(lele))
                            {
                                if (!(_OrdPaStrofe[lele].Contains(strofe)))
                                {
                                    _OrdPaStrofe[lele] += strofe + ", ";
                                }
                                else
                                {
                                    _OrdPaStrofe[lele] = _OrdPaStrofe[lele].Remove(_OrdPaStrofe[lele].Length - 2);
                                    _OrdPaStrofe[lele] += "*, ";
                                }
                            }
                            else
                            {
                                _OrdPaStrofe[lele] = strofe + ", ";
                            }
                        }
                        
                        if (lele != string.Empty && lele != "strofe")
                        {
                            if (dictionary.ContainsKey(lele))
                            {
                                // If in dic we ++
                                dictionary[lele]++;
                            }
                            else
                            {
                                // If not in dic we add
                                dictionary[lele] = 1;
                            }
                        }
                    }
                }
            }

            Dictionary<string, int> sortedDict = new Dictionary<string, int>();

            var sorted = dictionary.Keys.ToList();
            sorted.Sort();

            foreach (var key in sorted)
            {
                sortedDict.Add(key, dictionary[key]);
            }

            return sortedDict;
        }

        public Dictionary<string, string> OrdPaStrofe
        {
            get { return _OrdPaStrofe; }
        }

        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-åA-Å]", "", RegexOptions.Compiled);
        }

        private static string KunTall(string str)
        {
            return Regex.Replace(str, "[^0-9]", "", RegexOptions.Compiled);
        }
    }
}
