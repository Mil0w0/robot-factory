using System;
using IO;
using RobotFactory;

public class SaveOutputCommand : IConsoleCommand
{
    private readonly string _outputPath;

    public SaveOutputCommand(Factory factory, string input)
    {
        _outputPath = input.Substring("SAVE_OUTPUT".Length).Trim();
    }

    public void Execute()
    {
        if (string.IsNullOrEmpty(_outputPath))
        {
            Console.WriteLine("Chemin de fichier manquant. Utilisez : SAVE_OUTPUT chemin/fichier.txt");
            return;
        }

        try
        {
            OutputManager.Start(_outputPath);
            Console.WriteLine($"La sortie est maintenant enregistrée dans : {_outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'activation de la redirection : {ex.Message}");
        }
    }
}