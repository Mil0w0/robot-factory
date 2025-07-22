using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace IO
{
    public class JsonScriptReader : IScriptReader
    {
        public List<string> ReadInstructions(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Fichier introuvable : {filePath}");

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                var script = JsonSerializer.Deserialize<JsonScript>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (script == null || script.Commands.Count == 0)
                    throw new InvalidDataException("Fichier JSON vide ou mal formé.");

                var lines = new List<string>();
                foreach (var cmd in script.Commands)
                {
                    string line = string.IsNullOrWhiteSpace(cmd.Args)
                        ? cmd.Instruction
                        : $"{cmd.Instruction} {cmd.Args}";
                    lines.Add(line);
                }

                return lines;
            }
            catch (JsonException e)
            {
                throw new InvalidDataException("Erreur de lecture JSON : " + e.Message);
            }
        }
    }
}