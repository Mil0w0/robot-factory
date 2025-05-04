namespace RobotFactory;

public class Utils
{
    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERROR");
        Console.ResetColor();
        Console.WriteLine($" {message}");
    }
    
    public static string GetUserInput(string message)
    {
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine();
        Console.ResetColor();
        return input;
    }
}