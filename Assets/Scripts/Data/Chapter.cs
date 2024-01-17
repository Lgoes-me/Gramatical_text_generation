using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class Chapter : ScriptableObject
    {
        [field: SerializeField]
        [field: SerializeReference]
        private List<TextEvent> TextEvents { get; set; }
        
        public Domain.Chapter ToDomain()
        {
            var textEvents = TextEvents.Select(r => r.ToDomain()).ToList();
            return new Domain.Chapter(textEvents);
        }
    }
}