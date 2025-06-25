using System.Runtime.CompilerServices;
using RobotFactory;

//INITIALIZATION OF THE FACTORY
string input = "";
Factory ourFactory = new Factory();
ourFactory.AddDefaultRobotTemplates();


//INFINITE MENU LOOP
Console.WriteLine("Welcome to the factory!");
Console.WriteLine("Enter 'Q' to quit.");
Console.WriteLine("Enter 'STOCKS' to check the factory stocks.");
Console.WriteLine("Enter 'NEEDED_STOCKS 1 XM-1, 2 RD-1' to check the stocks needed for those robots.");
Console.WriteLine("Enter 'PRODUCE 1 XM-1' to create it and update stock.");
Console.WriteLine("Enter 'ADD_TEMPLATE TEST Core_CM1, Generator_GM1, Arms_AM1, Legs_LM1' to create it and update stock.");
Console.WriteLine("Enter 'INSTRUCTIONS 1 XM-1' to see the steps to create 1 XM-1 robot.");
Console.WriteLine("Enter 'VERIFY 1 XM-1' to check availabilty of the command if we produce it.");

while (true)
{
    input = Utils.GetUserInput("Enter an instruction:");
    
    if (input.ToUpper() == "Q")
    {
        break;
    }
    else if (input.ToUpper() == "STOCKS")
    {
       ourFactory.ShowStock();
    }
    else if (input.ToUpper().StartsWith("NEEDED_STOCKS"))
    {
        Dictionary<string, int> robotQuantities = Utils.FilterCommand(input);
        ourFactory.CheckNeededStock(robotQuantities);
    }
    else if (input.ToUpper().StartsWith("INSTRUCTIONS"))
    {
        Dictionary<string, int> robotQuantities = Utils.FilterCommand(input);
        if (robotQuantities.Count == 0)
        {
            continue;
        }
        ourFactory.GetRobotProductionInstructions(robotQuantities);
        
    }
    else if (input.ToUpper().StartsWith("VERIFY"))
    {
        Dictionary<string, int> robotQuantities = Utils.FilterCommand(input);
        if (robotQuantities.Count == 0)
        {
           continue;
        }
        ourFactory.checkPiecesAvailability(robotQuantities);
    }
    else if (input.ToUpper().StartsWith("PRODUCE"))
    {
        Dictionary<string, int> robotQuantities = Utils.FilterCommand(input);
        bool isAvailable = ourFactory.checkPiecesAvailability(robotQuantities);
        if (!isAvailable)
        {
            continue;
        }
        ourFactory.ProduceRobot(robotQuantities);
    }
    else if (input.ToUpper().StartsWith("ADD_TEMPLATE"))
    {
        ourFactory.AddRobotTemplate( input);
    }
    else
    {
       Utils.ShowError("Invalid command. Please try again.");
    }
}




