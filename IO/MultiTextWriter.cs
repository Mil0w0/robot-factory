using System;
using System.IO;
using System.Text;

namespace IO
{

    public class MultiTextWriter : TextWriter
    {
        private readonly TextWriter _consoleWriter;
        private readonly TextWriter _fileWriter;

        public MultiTextWriter(TextWriter consoleWriter, TextWriter fileWriter)
        {
            _consoleWriter = consoleWriter;
            _fileWriter = fileWriter;
        }

        public override void Write(char value)
        {
            _consoleWriter.Write(value);
            _fileWriter.Write(value);
        }

        public override void WriteLine(string? value)
        {
            _consoleWriter.WriteLine(value);
            _fileWriter.WriteLine(value);
        }

        public override void Flush()
        {
            _consoleWriter.Flush();
            _fileWriter.Flush();
        }

        public override Encoding Encoding => _consoleWriter.Encoding;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fileWriter.Flush();
                _fileWriter.Dispose();
            }
        }
    }
}