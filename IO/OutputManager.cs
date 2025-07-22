using System;
using System.IO;
using System.Text;

namespace IO
{ 
    public static class OutputManager
    {
        private static TextWriter? _originalOut;
        private static StreamWriter? _fileWriter;
        private static MultiTextWriter? _multiWriter;

        private static bool _isActive = false;
        public static bool IsActive => _isActive;

        public static void Start(string outputPath)
        {
            if (_isActive) return;

            var directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            _originalOut = Console.Out;
            _fileWriter = new StreamWriter(outputPath, append: false)
            {
                AutoFlush = true
            };
            _multiWriter = new MultiTextWriter(_originalOut, _fileWriter);
            Console.SetOut(_multiWriter);

            _isActive = true;
        }

        public static void Stop()
        {
            if (!_isActive) return;

            Console.Out.Flush();
            _fileWriter?.Flush();

            _fileWriter?.Dispose();
            _fileWriter = null;
            _multiWriter = null;

            Console.SetOut(_originalOut ?? Console.Out);
            _isActive = false;
        }

        public static string? CurrentOutputFile => (_fileWriter as StreamWriter)?.BaseStream is FileStream fs
            ? fs.Name
            : null;
    }
}