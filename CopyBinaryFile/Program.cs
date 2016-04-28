using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main()
        {
            string duckImagePath = "../../duck.jpg";
            string duckCopyPath = "../../duckCopys.jpg";
            using (var source = new FileStream(duckImagePath, FileMode.Open))
            {
                using (var destination = new FileStream(duckCopyPath, FileMode.Create))
                {
                    byte[] buffe = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffe, 0, buffe.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffe, 0, readBytes);
                    }
                }
            }

        }
    }
}
