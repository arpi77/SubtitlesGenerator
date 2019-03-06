﻿using System.Collections.Generic;
using SubtitlesConverter.Domain.Models;
using SubtitlesConverter.Domain.TextProcessing;

namespace SubtitlesConverter.Domain
{
    public class SubtitleBuilder
    {
        private TimedText Text { get; set; } = TimedText.Empty;
        private ITextProcessor Processing { get; set; } = new DoNothing();

        public SubtitleBuilder For(TimedText text)
        {
            Text = text;
            return this;
        }

        public SubtitleBuilder Using(ITextProcessor textProcessor)
        {
            Processing.Then(textProcessor);
            return this;
        }


        public  Subtitles Build()
        {
            TimedText timedText = Text.Apply(Processing);

            TextDurationMeter durationMeter = new TextDurationMeter(timedText);

            IEnumerable<SubtitleLine> subtitles = durationMeter.MeasureLines();

            return new Subtitles(subtitles);
        }
    }
}