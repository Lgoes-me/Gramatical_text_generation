using System;
using System.Collections.Generic;
using Debug;

namespace Domain.Resolvers
{
    public class ActorResolver : Resolver
    {
        private List<string> Options { get; set; }

        public ActorResolver(string key, List<string> options) : base(key)
        {
            Options = options;
        }
        
        public override void Resolve(Action<string> callback)
        {
            var actor = GameplayScene.Instance.Actor;

            if (actor.Stats.TryGetValue(Key, out var stat))
            {
                callback(stat);
                return;
            }

            var result = Options[UnityEngine.Random.Range(0, Options.Count)];
            actor.Stats.TryAdd(Key, result);

            callback(result);
        }
    }
}