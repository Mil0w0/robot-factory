using RobotFactory.Commands;

namespace RobotFactory;

public static class ConsoleCommandFactory
{
    public static IConsoleCommand? Parse(string input, Factory factory)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (input.Length == 0) return null;

        var commandName = input.Split(' ')[0].ToUpperInvariant();

        return commandName switch
        {
            "STOCKS" => new ShowStockCommand(factory),
            "NEEDED_STOCKS" => new CheckNeededStockCommand(factory, input),
            "INSTRUCTIONS" => new GetInstructionsCommand(factory, input),
            "VERIFY" => new VerifyCommand(factory, input),
            "PRODUCE" => new ProduceRobotCommand(factory, input),
            "ADD_TEMPLATE" => new AddTemplateCommand(factory, input),
            "RECEIVE" => new ReceiveStockCommand(factory, input),
            "ORDER" => new SaveOrderCommand(factory, input),
            "LIST_ORDER" => new ListOrdersCommand(factory),
            "SEND" => new SendCommand(factory, input),
            "LOAD" => new LoadScriptCommand(factory, input),
            "SAVE_OUTPUT" => new SaveOutputCommand(factory, input),
            _ => null
        };
    }
}