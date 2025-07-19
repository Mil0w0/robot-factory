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
        ourFactory.AddRobotTemplate(input);
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
    else if (input.ToUpper().StartsWith("ORDER"))
    {
        Dictionary<string, int> itemQuantities = Utils.FilterCommand(input);
        if (itemQuantities.Count == 0)
        {
            continue;
        }

        ourFactory.SaveOrder(itemQuantities);
    }
    else if (input.ToUpper().StartsWith("LIST_ORDER"))
    {
        ourFactory.ListOrders();
    }
    else if (input.ToUpper().StartsWith("SEND"))
    {
        string parts = input.Substring("SEND ".Length).Trim();
        int commaIndex = parts.IndexOf(",");
        if (commaIndex == -1)
        {
           Utils.ShowError("Invalid SEND command. Format: SEND ORDERID, ARGS");
            continue;
        }

        string orderId = parts.Substring(0, commaIndex).Trim();
        string robotsPart = parts.Substring(commaIndex + 1).Trim();

        Dictionary<string, int> robotQuantities = Utils.ParseRobotQuantities(robotsPart);
        if (robotQuantities.Count == 0)
        {
            continue;
        }
        
        ourFactory.Send(int.Parse(orderId), robotQuantities);
    }
    else
    {
        Utils.ShowError("Invalid command. Please try again.");
    }
}