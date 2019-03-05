using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    internal interface ITextProcessor
    {
        IEnumerable<string> Execute(IEnumerable<string> text);
    }
}