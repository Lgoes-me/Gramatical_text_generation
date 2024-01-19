using System;
using Domain.Stories;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class LockedEntityData
    {
        [field: SerializeField] 
        public StatActor StatActor { get; private set; }
        
        [field: SerializeField] 
        public string LockedByStat { get; private set; }
        
        [field: SerializeField] 
        public string LockedByStatValue { get; private set; }
    }
}