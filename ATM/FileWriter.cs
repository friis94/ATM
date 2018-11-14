﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FileWriter : IFileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteLine(string stringData)
        {
            System.IO.File.AppendAllText(_filePath, stringData + Environment.NewLine);
        }
    }
}
