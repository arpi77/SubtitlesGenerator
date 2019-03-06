using System;

namespace SubtitlesConverter.Domain.Models
{
    public class SubtitleLine
    {
        public string Content { get; }
        public TimeSpan Duration { get; }

        public SubtitleLine(string content, TimeSpan duration)
        {
            this.Content = content.Trim();
            this.Duration = duration;
        }

        public override string ToString() =>
            $"{this.Duration} --> {this.Content}";
    }
}