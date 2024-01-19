using System.Collections.Generic;
using Domain.Resolvers;
using UnityEngine;

namespace Data.Resolvers
{
    [System.Serializable]
    public class StatResolver : Resolver
    {
        [field: SerializeField]
        private string Stat { get; set; }
        
        [field: SerializeField]
        private List<StatOption> Options { get; set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.StatResolver(Key, Stat, Options);
        }
    }
}