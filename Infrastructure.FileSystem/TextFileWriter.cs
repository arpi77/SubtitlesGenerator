using System.Collections.Generic;
using System.IO;
using System.Text;
using SubtitlesConverter.Domain;

namespace SubtitleGenerator.Infrastructure.FileSystem
{
    public class TextFileWriter : ITextWriter
    {
        public TextFileWriter(FileInfo destination)
        {
            Destination = destination;
        }

        public FileInfo Destination { get; }

        public void Write(IEnumerable<string> lines)
        {
            File.WriteAllLines(Destination.FullName, lines, Encoding.UTF8);
        }
    }
}