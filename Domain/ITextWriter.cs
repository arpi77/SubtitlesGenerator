using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    public interface ITextWriter
    {
        void Write(IEnumerable<string> lines);
    }
}