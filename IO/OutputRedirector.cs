using System;
using System.IO;

namespace IO
{
    public static class OutputRedirector
    {
        private static TextWriter? originalOutput = null;
        private static StreamWriter? fileWriter = null;

        public static void Start(string outputPath)
        {
            originalOutput = Console.Out;
            fileWriter = new StreamWriter(outputPath);
            Console.SetOut(fileWriter);
        }

        public static void Stop()
        {
            if (fileWriter != null)
            {
                fileWriter.Flush();
                fileWriter.Close();
                fileWriter = null;
                Console.SetOut(originalOutput ?? Console.Out);
            }
        }

        public static bool IsActive => fileWriter != null;
    }
}