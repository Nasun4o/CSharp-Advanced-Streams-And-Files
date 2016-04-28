using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    class Program
    {
        public static void Main()
        {
          
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                string line = reader.ReadLine();

                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
