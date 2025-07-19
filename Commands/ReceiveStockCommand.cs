namespace RobotFactory.Commands;

public class ReceiveStockCommand(Factory factory, string input) : IConsoleCommand
{
    private readonly Dictionary<string, int> _itemQuantities = Utils.FilterCommand(input);

    public void Execute()
    {
        if (_itemQuantities.Count == 0)
        {
            return;
        }

        factory.ReceivesStocks(_itemQuantities);
    }
}