using System.Collections.Generic;
using UnityEngine;

namespace Data.Resolvers
{
    [System.Serializable]
    public class StatValueResolver : Resolver
    {
        [field: SerializeField]
        private List<string> Options { get; set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.StatValueResolver(Key, Options);
        }
    }
}