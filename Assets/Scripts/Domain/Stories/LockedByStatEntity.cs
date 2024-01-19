using System;
using Debug;
using Domain.Actors;

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
            if (StatActor == StatActor.Unlocked)
            {
                return true;
            }
            
            var actor = StatActor switch
            {
                StatActor.World => GameplayScene.Instance.World,
                StatActor.Player => GameplayScene.Instance.World.Player,
                StatActor.Chapter => GameplayScene.Instance.Chapter,
                
                _ => throw new ArgumentOutOfRangeException()
            };
            
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
        Unlocked,
        Player,
        World,
        Chapter,
    }
}