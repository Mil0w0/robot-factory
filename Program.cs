using System.Runtime.CompilerServices;
using RobotFactory;

//INITIALIZATION OF THE FACTORY
string input = "";
Factory ourFactory = new Factory();


//INFINITE MENU LOOP
Console.WriteLine("Welcome to the factory!");
Console.WriteLine("Enter 'Q' to quit.");
Console.WriteLine("Enter 'STOCKS' to check the factory stocks.");
Console.WriteLine("Enter 'INSTRUCTIONS 1 XM-1' to see the steps to create 1 XM-1 robot.");

while (input.ToUpper() != "Q")
{
    input = Utils.GetUserInput("Enter a input:");
    
    if (input.ToUpper() == "STOCKS")
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
        ourFactory.GetRobotProductionInstructions(robotQuantities);
        
    }
    else if (input.ToUpper().StartsWith("VERIFY"))
    {
        Dictionary<string, int> robotQuantities = Utils.FilterCommand(input);
        ourFactory.checkPiecesAvailability(robotQuantities);
    }
    else if (input.ToUpper().StartsWith("PRODUCE"))
    {
        
    }
    else
    {
       Utils.ShowError("Invalid command. Please try again.");
    }
}

return 0;



