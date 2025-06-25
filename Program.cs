using System.Runtime.CompilerServices;
using RobotFactory;

//INITIALIZATION OF THE FACTORY
string input = "";
Factory ourFactory = new Factory();
ourFactory.AddDefaultRobotTemplates();


//INFINITE MENU LOOP
while (true)
{
    Utils.DisplayCommands();
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
    else if (input.ToUpper().StartsWith("RECEIVE"))
    {
        
        Dictionary<string, int> itemQuantities = Utils.FilterCommand(input);
        if (itemQuantities.Count == 0)
        {
            continue;
        }
        ourFactory.ReceivesStocks(itemQuantities);
    }
    else
    {
       Utils.ShowError("Invalid command. Please try again.");
    }
}




