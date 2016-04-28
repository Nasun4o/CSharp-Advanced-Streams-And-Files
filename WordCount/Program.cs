using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> results = new Dictionary<string, int>();
            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader("../../words.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                }
            }
            foreach (var word in words)
            {
                using (StreamReader reader = new StreamReader("../../Text.txt"))
                {
                    string text = reader.ReadToEnd();
                    results.Add(word, WordCounter(text, word));
                }
            }

            results = results.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, k => k.Value);
            using (StreamWriter writer = new StreamWriter("../../ruslt.txt"))
            {
                foreach (KeyValuePair<string, int> word in results)
                {
                    string output = string.Empty + word.Key + " " + word.Value;
                    writer.WriteLine(output);
                }
            }

        }

        public static int WordCounter(string text, string match)
        {
            MatchCollection collection = Regex.Matches(text, @"\b" + match + @"\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return collection.Count;
        }
    }
}
