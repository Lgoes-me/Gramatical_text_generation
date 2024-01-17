using System.Collections.Generic;
using UnityEngine;

namespace Data.Resolvers
{
    public class InputDropdownResolver : InputResolver
    {
        [field: SerializeField]
        private List<string> Options { get; set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.InputDropdownResolver(Key, Tittle, Options, Save);
        }
    }
}