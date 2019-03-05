using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing
{
    internal class LinesTrimmer : ITextProcessor
    {
        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            text
                .Select(line => line.Trim())
                .Where(line => line.Length > 0);
    }
}