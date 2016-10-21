using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using CSharpOv6.Classes;

namespace CSharpOv6
{
    class Program
    {
        static void Main(string[] args)
        {

            Read rd = new Read();

            Dictionary<string, int> dictionary = rd.File("havamal.txt");

            Dictionary<string, string> Strofe = rd.OrdPaStrofe;

            int count = 1;
            
            Console.WriteLine("#\tOrd\t\tAntall\tStrofe");
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                //loop sorted dic from dic

                if (pair.Key.Length > 7)
                {
                    Console.WriteLine(count + "\t" + pair.Key + "\t" + pair.Value + "\t" + Strofe[pair.Key]);
                }
                else
                {
                    Console.WriteLine(count + "\t" + pair.Key + "\t\t" + pair.Value + "\t" + Strofe[pair.Key]);
                }
                
                count++;

                //if count = 10 brek, dis maks 10 words ut
                //if (countt > 10)
                //{
                //    break;
                //}
            }
            
            Console.Read();
        }
    }
}
