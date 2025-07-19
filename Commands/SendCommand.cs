namespace RobotFactory.Commands;

public class SendCommand : IConsoleCommand
{
    private readonly Factory _factory;
    private readonly int _orderId;
    private readonly Dictionary<string, int>? _robotQuantities;

    public SendCommand(Factory factory, string input)
    {
        _factory = factory;

        string parts = input.Substring("SEND ".Length).Trim();
        int commaIndex = parts.IndexOf(",");
        if (commaIndex == -1)
        {
            Utils.ShowError("Invalid SEND command. Format: SEND ORDERID, ARGS");
            return;
        }

        string orderIdPart = parts.Substring(0, commaIndex).Trim();
        if (!int.TryParse(orderIdPart, out _orderId))
        {
            Utils.ShowError("Invalid ORDERID in SEND command. It must be an integer.");
            return;
        }

        _orderId = int.Parse(orderIdPart);
        string robotsPart = parts.Substring(commaIndex + 1).Trim();

        _robotQuantities = Utils.ParseRobotQuantities(robotsPart);
    }

    public void Execute()
    {
        if (_robotQuantities == null || _robotQuantities.Count == 0)
        {
            return;
        }

        _factory.Send(_orderId, _robotQuantities);
    }
}