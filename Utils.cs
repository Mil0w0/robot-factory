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
            string itemName = robotCommand[2];
          
            bool isPiece = Stock.Instance.GetPiece(itemName) != null;
            bool isTemplate = BookOfTemplates.Instance.GetTemplate(itemName) != null;

            if (!isPiece && !isTemplate)
            {
                ShowError($"{itemName} is not a recognized piece or robot.");
                continue;
            }
            
            if (int.Parse(quantity) <= 0)
            {
                ShowError("Invalid quantity.");
                continue;
            }

            if (robotQuantities.ContainsKey(itemName))
            {
                robotQuantities[itemName] += int.Parse(quantity);
            }
            else
            {
                robotQuantities.Add(itemName, int.Parse(quantity));
            }
        }

        return robotQuantities;
    }

    public static void DisplayCommands()
    {
        Console.WriteLine("Welcome to the factory!");
        Console.WriteLine("Enter 'Q' to quit.");
        Console.WriteLine("Enter 'STOCKS' to check the factory stocks.");
        Console.WriteLine("Enter 'NEEDED_STOCKS 1 XM-1, 2 RD-1' to check the stocks needed for those robots.");
        Console.WriteLine("Enter 'PRODUCE 1 XM-1' to create it and update stock.");
        Console.WriteLine("Enter 'ADD_TEMPLATE TEST Core_CM1, Generator_GM1, Arms_AM1, Legs_LM1' to create it and update stock.");
        Console.WriteLine("Enter 'INSTRUCTIONS 1 XM-1' to see the steps to create 1 XM-1 robot.");
        Console.WriteLine("Enter 'VERIFY 1 XM-1' to check availabilty of the command if we produce it.");
        Console.WriteLine("Enter 'RECEIVE 1 XM-1, 2 Arms_AI1' to add 1 XM-1 and 2 arms to the stock.");

    }
}