﻿using System;
using System.Collections.Generic;
using System.IO;


class SlicingFile
{
    public static List<string> files = new List<string>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        SplitFile(@"..\..\input.avi", @"..\..\", n);
        AssembleFile(files, @"..\..\");

    }
    public static void SplitFile(string inputFile, string path, int parts)
    {
        byte[] byteSource = File.ReadAllBytes(inputFile);
        FileInfo info = new FileInfo(inputFile);
        int partSize = (int)Math.Ceiling((double)(info.Length / parts));
        int fileOffset = 0;
        string currPartPath;
        FileStream fsPart;
        int sizeRemaining = (int)info.Length;
        for (int i = 0; i < parts; i++)
        {
            currPartPath = path + "part-" + i + info.Extension;
            files.Add(currPartPath);
            if (!File.Exists(currPartPath))
            {
                fsPart = new FileStream(currPartPath, FileMode.CreateNew);
                sizeRemaining = (int)info.Length - (i * partSize);
                if (sizeRemaining < partSize)
                {
                    partSize = sizeRemaining;
                }
                fsPart.Write(byteSource, fileOffset, partSize);
                fsPart.Close();
                fileOffset += partSize;
            }
        }
    }
    public static void AssembleFile(List<string> files, string destination)
    {
        string fullPath = destination + "assembled.avi";
        FileStream fsSource = new FileStream(fullPath, FileMode.Append);
        foreach (string path in files)
        {
            byte[] bytePart = File.ReadAllBytes(path);
            fsSource.Write(bytePart, 0, bytePart.Length);
        }
        fsSource.Close();
    }
}