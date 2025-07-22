using System.Collections.Generic;

namespace IO
{
    public class JsonScript
    {
        public string? ScriptName { get; set; }
        public string? Author { get; set; }
        public List<JsonCommand> Commands { get; set; } = new();
    }

    public class JsonCommand
    {
        public string Instruction { get; set; } = string.Empty;
        public string? Args { get; set; }
    }
}