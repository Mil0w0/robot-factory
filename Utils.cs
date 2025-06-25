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

    // The factory wants to group all same robot types together when an instruction is run.
    public static Dictionary<string, int> FilterCommand(string input)
    {
        Dictionary<string, int> robotQuantities = new Dictionary<string, int>();
        string[] robots = input.Split(",");
        foreach (var robot in robots)
        {
            string[] robotCommand = robot.Split(" ");
            string quantity = robotCommand[1];
            string robotName = robotCommand[2];
          
            var template = BookOfTemplates.Instance.GetTemplate(robotName);

            if (template == null)
            {
                ShowError($"{robotName} is not a recognized robot.");
                continue;
            }

            if (int.Parse(quantity) <= 0)
            {
                ShowError("Invalid quantity.");
                continue;
            }

            if (robotQuantities.ContainsKey(robotName))
            {
                robotQuantities[robotName] += int.Parse(quantity);
            }
            else
            {
                robotQuantities.Add(robotName, int.Parse(quantity));
            }
        }

        return robotQuantities;
    }
}