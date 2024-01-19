using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class Chapter : ScriptableObject
    {
        [field: SerializeField] 
        private LockedEntityData LockedEntityData { get; set; }
        
        [field: SerializeField]
        [field: SerializeReference]
        private List<TextEvent> TextEvents { get; set; }
        
        public Domain.Stories.Chapter ToDomain()
        {
            var textEvents = TextEvents.Select(r => r.ToDomain()).ToList();
            
            return new Domain.Stories.Chapter(
                textEvents, 
                LockedEntityData.StatActor, 
                LockedEntityData.LockedByStat,
                LockedEntityData.LockedByStatValue);
        }
    }
}