using System.Collections.Generic;

namespace IO
{ 
    public interface IScriptReader
    {
        List<string> ReadInstructions(string filePath);
    }
}