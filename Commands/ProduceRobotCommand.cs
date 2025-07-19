namespace RobotFactory.Commands;

public class ProduceRobotCommand(Factory factory, string input) : IConsoleCommand
{
    private readonly Dictionary<string, int> _robotQuantities = Utils.FilterCommand(input);

    public void Execute()
    {
        if (!factory.checkPiecesAvailability(_robotQuantities))
        {
            return;
        }

        factory.ProduceRobot(_robotQuantities);
    }

}