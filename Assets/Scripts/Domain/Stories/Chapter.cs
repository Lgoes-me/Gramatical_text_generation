using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Stories
{
    public class Chapter : LockedByStatEntity
    {
        private int Tempo { get; set; }
        private int TempoMaximo { get; set; }
        private List<TextEvent> TextEvents { get; }

        public Chapter(
            List<TextEvent> textEvents,
            StatActor statActor,
            string lockedByStat,
            string lockedByStatValue) : base(statActor, lockedByStat, lockedByStatValue)
        {
            TextEvents = textEvents.OrderBy(t => t.Tempo).ToList();
            Tempo = 0;
            TempoMaximo = textEvents.Last().Tempo;
        }

        public void Resolve(Action<string> callback, Action getNextChapter)
        {
            if (GetNextEvent(out var nextEvent))
            {
                nextEvent.Resolve(callback);
            }
            else
            {
                getNextChapter();
            }
        }

        private bool GetNextEvent(out TextEvent textEvent)
        {
            textEvent = null;
            
            while (Tempo <= TempoMaximo )
            {
                Tempo++;
                
                textEvent = TextEvents
                    .Where(t => t.Tempo == Tempo && t.IsUnlocked())
                    .OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                if (textEvent != null)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}