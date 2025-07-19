namespace RobotFactory.Commands;

public class VerifyCommand(Factory factory, string input) : IConsoleCommand
{
    private readonly Dictionary<string, int> _robotQuantities = Utils.FilterCommand(input);

    public void Execute()
    {
        if (_robotQuantities.Count == 0)
        {
            return;
        }
        factory.checkPiecesAvailability(_robotQuantities);
    }
    
} 