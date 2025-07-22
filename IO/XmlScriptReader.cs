using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace IO
{
    [XmlRoot("Instructions")]
    public class XmlInstructionList
    {
        [XmlElement("Instruction")]
        public List<string> Instructions { get; set; }
    }

    public class XmlScriptReader : IScriptReader
    {
        public List<string> ReadInstructions(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Fichier introuvable : {filePath}");

            try
            {
                var serializer = new XmlSerializer(typeof(XmlInstructionList));
                using var reader = new StreamReader(filePath);

                var instructionList = serializer.Deserialize(reader) as XmlInstructionList;
                if (instructionList == null || instructionList.Instructions == null)
                    throw new InvalidDataException("Fichier XML vide ou invalide.");

                return instructionList.Instructions;
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidDataException("Erreur de lecture du fichier XML : " + e.Message);
            }
        }
    }
}