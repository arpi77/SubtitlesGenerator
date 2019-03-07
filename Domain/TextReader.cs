using SubtitlesConverter.Domain.Models;

namespace SubtitlesConverter.Domain
{
    class TextReader : ITextReader
    {
        public static ITextReader Empty { get; } = new TextReader();

        private TextReader()
        {
        }

        public TimedText Read() => TimedText.Empty;
    }
}