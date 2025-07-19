namespace RobotFactory.Commands;

public class ShowStockCommand(Factory factory) : IConsoleCommand
{
    public void Execute()
    {
        factory.ShowStock();
    }
} 