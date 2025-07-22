using System;
using System.Collections.Generic;
using System.IO;

namespace IO
{
    public class TxtScriptReader : IScriptReader
    {
        public List<string> ReadInstructions(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Fichier introuvable : {filePath}");

            var lines = File.ReadAllLines(filePath);
            var instructions = new List<string>();

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    instructions.Add(trimmed);
                }
            }

            return instructions;
        }
    }
}