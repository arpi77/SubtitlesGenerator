using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing
{
    public interface ITextProcessor
    {
        IEnumerable<string> Execute(IEnumerable<string> text);
    }
}