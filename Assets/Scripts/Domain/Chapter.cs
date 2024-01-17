using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Chapter
    {
        private int Tempo { get; set; }
        private List<TextEvent> TextEvents { get; }
        
        public Chapter(List<TextEvent> textEvents)
        {
            Tempo = 1;
            TextEvents = textEvents.OrderBy(t => t.Tempo).ToList();
        }

        public void Resolve(Action<string> callback)
        {
            var nextEvent = GetNextEvent();

            if (nextEvent != null)
            {
                GetNextEvent().Resolve(callback);
                Tempo++;
            }
        }

        private TextEvent GetNextEvent()
        {
            return TextEvents.Where(t => t.Tempo == Tempo).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }
}