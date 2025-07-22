using System;
using System.IO;
using System.Collections.Generic;
using RobotFactory;
using IO;

namespace IO
{
    public static class ScriptExecutor
    {
        public static void Run(string inputFilePath, string outputFilePath)
        {
            // Sélection dynamique du bon reader
            IScriptReader reader = ScriptReaderFactory.GetReader(inputFilePath);
            List<string> lines = reader.ReadInstructions(inputFilePath);

            var factory = new Factory();
            factory.AddDefaultRobotTemplates();

            using var writer = new StreamWriter(outputFilePath);
            var originalOut = Console.Out;
            Console.SetOut(writer); 

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    var command = ConsoleCommandFactory.Parse(line, factory);
                    command?.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }

            Console.SetOut(originalOut);
            Console.WriteLine($"Script exécuté. Résultat sauvegardé dans : {outputFilePath}");
        }
    }
}