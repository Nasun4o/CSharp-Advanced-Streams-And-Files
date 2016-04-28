using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../text1.text"))
                {
                    int count = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string output = "" + count + " " + line;
                        writer.WriteLine(output);
                        count++;
                    }

                }
            }       
        }
    }
}
