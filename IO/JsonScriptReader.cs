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
                var instructions = JsonSerializer.Deserialize<List<string>>(jsonContent);

                if (instructions == null)
                    throw new InvalidDataException("Fichier JSON vide ou invalide.");

                return instructions;
            }
            catch (JsonException e)
            {
                throw new InvalidDataException("Erreur de lecture du fichier JSON : " + e.Message);
            }
        }
    }
}