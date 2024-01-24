using System.Collections.Generic;
using UnityEngine;

namespace Data.Resolvers
{
    [System.Serializable]
    public class ActorResolver: Resolver
    {
        //Qual o nome(StatToRead) do personagem que tenha o stat NPC(ActorStat) com valor Inimigo(ActorStatValue) ?
        //Se não existir um criar(CreateIfNecessary) 
        //Options para resolver o stat se não existir 

        [field: SerializeField] 
        public string StatToRead { get; private set; }
        
        [field: SerializeField] 
        public string ActorStat { get; private set; }
        
        [field: SerializeField] 
        public string ActorStatValue { get; private set; }
        
        [field: SerializeField] 
        public bool CreateIfNecessary { get; private set; }
        
        [field: SerializeField]
        public List<string> Options { get; private set; }
        
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.ActorResolver(Key, StatToRead, ActorStat, ActorStatValue, CreateIfNecessary, Options);
        }
    }
}