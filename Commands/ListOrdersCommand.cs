namespace RobotFactory.Commands;

public class ListOrdersCommand(Factory factory) : IConsoleCommand
{
    public void Execute()
    {
        factory.ListOrders();
    }
}