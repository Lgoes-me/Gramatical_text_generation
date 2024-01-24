using System;
using System.Collections.Generic;
using System.Linq;
using Debug;
using Domain.Actors;

namespace Domain.Resolvers
{
    public class ActorResolver : Resolver
    {
        private string StatToRead { get; }
        private string ActorStat { get; }
        private string ActorStatValue { get; }
        private bool CreateIfNecessary { get; } 
        
        private List<string> Options { get; set; }
        
        public ActorResolver(string key,
            string statToRead,
            string actorStat,
            string actorStatValue,
            bool createIfNecessary, 
            List<string> options) : base(key)
        {
            StatToRead = statToRead;
            ActorStat = actorStat;
            ActorStatValue = actorStatValue;
            CreateIfNecessary = createIfNecessary;
            Options = options;
        }

        public override void Resolve(Action<string> callback)
        {
            var world = GameplayScene.Instance.World;

            if (string.IsNullOrWhiteSpace(ActorStat))
            {
                //just create new actor
                var newActor = world.CreateActor();
                callback(ResolveActorStatValue(newActor));
                return;
            }
            
            var actor = world.Actors.FirstOrDefault(a => a.Stats.ContainsKey(ActorStat));

            if (actor == null)
            {
                //create new actor and give actor stat
                var newActor = world.CreateActor(ActorStat, ActorStatValue);
                callback(ResolveActorStatValue(newActor));
                return;
            }
            
            var currentStatValue = actor.Stats[ActorStat];
            
            if (string.IsNullOrWhiteSpace(ActorStatValue) || currentStatValue == ActorStatValue)
            {
                //its him
                callback(ResolveActorStatValue(actor));
                return;
            }

            // create new actor
            if (CreateIfNecessary)
            {
                var newActor = world.CreateActor(ActorStat, ActorStatValue);
                callback(ResolveActorStatValue(newActor));
                return;
            }
            
            //change stats

            actor.Stats[ActorStat] = ActorStatValue;
            callback(ResolveActorStatValue(actor));
        }

        private string ResolveActorStatValue(Actor actor)
        {
            if (actor.Stats.TryGetValue(Key, out var stat))
            {
                return stat;
            }

            var result = Options[UnityEngine.Random.Range(0, Options.Count)];
            actor.Stats.TryAdd(Key, result);

            return result;
        }
    }
}