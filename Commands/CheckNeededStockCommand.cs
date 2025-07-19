namespace RobotFactory.Commands;

public class CheckNeededStockCommand(Factory factory, string input) : IConsoleCommand
{
    private readonly Dictionary<string, int> _robotQuantities = Utils.FilterCommand(input);

    public void Execute()
    {
        factory.CheckNeededStock(_robotQuantities);
    }
}