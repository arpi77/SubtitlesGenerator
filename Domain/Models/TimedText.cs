using System;
using System.Collections.Generic;
using System.Linq;
using SubtitlesConverter.Domain.TextProcessing;

namespace SubtitlesConverter.Domain.Models
{
    public class TimedText
    {
        public IEnumerable<string> Content { get; }
        public TimeSpan Duration { get; }

        public TimedText(IEnumerable<string> content, TimeSpan duration)
        {
            Content = content;
            Duration = duration;
        }

        public static TimedText Empty =>
            new TimedText( Enumerable.Empty<string>(), TimeSpan.Zero);

        public TimedText Apply(ITextProcessor parsing) =>
            new TimedText(parsing.Execute(this.Content).ToList(), Duration);
    }
}
