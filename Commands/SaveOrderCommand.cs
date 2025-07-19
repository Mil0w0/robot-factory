namespace RobotFactory.Commands;

public class SaveOrderCommand(Factory factory, string input) : IConsoleCommand
{
    private readonly Dictionary<string, int> _itemQuantities = Utils.FilterCommand(input);

    public void Execute()
    {
        if (_itemQuantities.Count == 0)
        {
            return;
        }

        factory.SaveOrder(_itemQuantities);
    }
}