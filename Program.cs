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

    try
    {
        var command = ConsoleCommandFactory.Parse(input, ourFactory);
        if (command != null)
        {
            command.Execute();
        }
        else
        {
            Utils.ShowError("Invalid command. Please try again.");
        }
    }
    catch (ArgumentException ex)
    {
        Utils.ShowError(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        Utils.ShowError(ex.Message);
    }
}