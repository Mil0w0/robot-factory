using System.Runtime.CompilerServices;
using RobotFactory;

//INITIALIZATION OF THE FACTORY
string command = "";
Factory ourFactory = new Factory();


//INFINITE MENU LOOP
Console.WriteLine("Welcome to the factory!");
Console.WriteLine("Enter 'Q' to quit.");
Console.WriteLine("Enter 'STOCKS' to check the factory stocks.");
Console.WriteLine("Enter 'INSTRUCTIONS 1 XM-1' to see the steps to create 1 XM-1 robot.");

while (command.ToUpper() != "Q")
{
    command = Utils.GetUserInput("Enter a command:");
    
    if (command.ToUpper() == "STOCKS")
    {
       ourFactory.ShowStock();
    }
    else if (command.ToUpper().StartsWith("INSTRUCTIONS"))
    {
        
    }
    else if (command.ToUpper().StartsWith("VERIFY"))
    {
        
    }
    else if (command.ToUpper().StartsWith("PRODUCE"))
    {
        
    }
    else
    {
       Utils.ShowError("Invalid command. Please try again.");
    }
}

return 0;



