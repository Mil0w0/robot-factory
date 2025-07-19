namespace RobotFactory.Commands;

public class AddTemplateCommand(Factory factory, string input) : IConsoleCommand
{
    public void Execute()
    {
        factory.AddRobotTemplate(input);
    }
}