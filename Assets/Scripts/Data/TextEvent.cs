using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Data.Resolvers;

namespace Data
{
    [CreateAssetMenu]
    public class TextEvent : ScriptableObject
    {
        [field: SerializeField] 
        [field: TextAreaAttribute]
        private string Data { get; set; }

        [field: SerializeField] 
        private LockedEntityData LockedEntityData { get; set; }
        
        [field: SerializeField] 
        private int Tempo { get; set; }
        
        [field: SerializeField]
        [field: SerializeReference]
        private List<Resolver> Resolvers { get; set; }

        public Domain.Stories.TextEvent ToDomain()
        {
            var resolvers = Resolvers.Select(r => r.ToDomain()).ToList();
            
            return new Domain.Stories.TextEvent(
                Data,
                Tempo,
                resolvers,
                LockedEntityData.StatActor,
                LockedEntityData.LockedByStat,
                LockedEntityData.LockedByStatValue);
        }

        public void AddResolver(Resolver resolver)
        {
            Resolvers.Add(resolver);
        }
    }
}