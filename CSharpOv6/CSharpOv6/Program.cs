using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CSharpOv6
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            Dictionary<string, int> count = new Dictionary<string, int>();

            SortedDictionary<string, List<int>> srt = new SortedDictionary<string, List<int>>();

            string strofe = "";

            using (StreamReader sr = new StreamReader("havamal.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();

                    if (line.Contains("Strofe"))
                    {
                        strofe = line;
                    }

                    string[] words = line.Split(' ');
                    foreach (string word in words)
                    {

                        string lele = RemoveSpecialCharacters(word);

                        lele = lele.ToLower();

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
                        


                        //Console.WriteLine(lele);

                        foreach (Char c in word)
                        {
                            // ...
                        }
                    }
                    

                }
            }


            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine(item.Key + "\t" + item.Value);
            //}

            //Console.WriteLine(strofe);

            Dictionary<string, int> sortedDict = (from entry in dictionary
                              orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            //count loop
            int countt = 1;
            
            Console.WriteLine();
            foreach (KeyValuePair<string, int> pair in sortedDict)
            {
                //loop sorted dic from dic

                if (pair.Key.Length > 7)
                {
                    Console.WriteLine(countt + "\t" + pair.Key + "\t" + pair.Value);
                }
                else
                {
                    Console.WriteLine(countt + "\t" + pair.Key + "\t\t" + pair.Value);
                }
                
                countt++;

                //if count = 10 brek, dis maks 10 words ut
                //if (countt > 10)
                //{
                //    break;
                //}
            }


            Console.Read();
        }


        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-åA-Å]$", "", RegexOptions.Compiled);
        }
    }
}
