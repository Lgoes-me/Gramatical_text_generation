using System;
using Debug;
using Domain.Actors;
using Domain.Resolvers;

namespace Domain.Stories
{
    public class LockedByStatEntity : Actor
    {
        private StatActor StatActor { get; }
        private string LockedByStat { get; }
        private string LockedByStatValue { get; }

        protected LockedByStatEntity(StatActor statActor, string lockedByStat, string lockedByStatValue) : base()
        {
            StatActor = statActor;
            LockedByStat = lockedByStat;
            LockedByStatValue = lockedByStatValue;
        }

        public bool IsUnlocked()
        {
            if (StatActor == StatActor.Undefined)
            {
                return true;
            }
            
            var actor = StatActor.ToActor();
            
            if (string.IsNullOrWhiteSpace(LockedByStat))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(LockedByStatValue))
            {
                return actor.Stats.ContainsKey(LockedByStat);
            }
            
            return actor.Stats.ContainsKey(LockedByStat) && actor.Stats[LockedByStat] == LockedByStatValue;
        }
    }

    public enum StatActor
    {
        Undefined,
        Player,
        World,
        Chapter,
    }
}