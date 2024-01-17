using System.Collections.Generic;
using UnityEngine;

namespace Data.Resolvers
{
    [System.Serializable]
    public class ActorResolver : Resolver
    {
        [field: SerializeField]
        private List<string> Options { get; set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.ActorResolver(Key, Options);
        }
    }
}