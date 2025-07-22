using System;
using System.IO;

namespace IO
{

    public static class ScriptReaderFactory
    {
        public static IScriptReader GetReader(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".txt" => new TxtScriptReader(),
                ".json" => new JsonScriptReader(),
                ".xml" => new XmlScriptReader(),
                _ => throw new NotSupportedException($"Extension non supportée : {extension}")
            };
        }
    }
}