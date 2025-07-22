using System;
using System.Collections.Generic;
using IO;
using RobotFactory;

public class LoadScriptCommand : IConsoleCommand
{
    private readonly string _scriptPath;
    private readonly Factory _factory;

    public LoadScriptCommand(Factory factory, string input)
    {
        _factory = factory;
        _scriptPath = input.Substring("LOAD".Length).Trim();
    }

    public void Execute()
    {
        try
        {
            IScriptReader reader = ScriptReaderFactory.GetReader(_scriptPath);
            List<string> lines = reader.ReadInstructions(_scriptPath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    var command = ConsoleCommandFactory.Parse(line, _factory);
                    command?.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Erreur dans la ligne du script] {line}");
                    Console.WriteLine($" -> {ex.Message}");
                }
            }

            Console.WriteLine($"LScript exécuté depuis : {_scriptPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du chargement du script : {ex.Message}");
        }
    }
}