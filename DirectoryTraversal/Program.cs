using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string[] files = Directory.GetFiles(path);
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            if (results.ContainsKey(info.Extension))
            {
                string fileInfo = string.Format("--{0}{1} - {2:F2}kb", info.Name, info.Extension, info.Length / 1024.0);
                results[info.Extension].Add(fileInfo);
            }
            else
            {
                results.Add(info.Extension, new List<string>());
                string fileInfo = string.Format("--{0}{1} - {2:F2}kb", info.Name, info.Extension, info.Length / 1024.0);
                results[info.Extension].Add(fileInfo);
            }
        }

        desktopPath += "\\results.txt";
        results = results.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        using (StreamWriter resultStream = new StreamWriter(desktopPath))
        {
            foreach (KeyValuePair<string, List<string>> result in results)
            {
                resultStream.WriteLine(result.Key);
                result.Value.Sort();
                foreach (string fileInfo in result.Value)
                {
                    resultStream.WriteLine(fileInfo);
                }
            }

        }
        Console.WriteLine();
    }
}