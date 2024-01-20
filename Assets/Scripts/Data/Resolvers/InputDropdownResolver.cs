using System.Collections.Generic;
using Domain.Resolvers;
using Domain.Stories;
using UnityEngine;

namespace Data.Resolvers
{
    public class InputDropdownResolver : InputResolver
    {
        [field: SerializeField] 
        private StatActor StatActor { get; set; }
        
        [field: SerializeField]
        private List<StatOption> Options { get; set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.InputDropdownResolver(Key, Tittle, StatActor, Options, Save);
        }
    }
}