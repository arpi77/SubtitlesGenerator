using SubtitlesConverter.Domain.Models;

namespace SubtitlesConverter.Domain
{
    public interface ITextReader
    {
        TimedText Read();
    }
}