using System;
using Debug;

namespace Domain.Resolvers
{
    public abstract class InputResolver : Resolver
    {
        public string Tittle { get; private set; }
        private bool Save { get; set; }
        
        protected InputResolver(string key, string tittle, bool save) : base(key)
        {
            Tittle = tittle;
            Save = save;
        }
        
        public override void Resolve(Action<string> callback)
        {
            if (!Save)
            {
                GameplayScene.Instance.OpenModal(this, callback);
                return;
            }
            
            var actor = GameplayScene.Instance.World.Player;

            if (actor.Stats.TryGetValue(Key, out var stat))
            {
                callback(stat);
                return;
            }

            GameplayScene.Instance.OpenModal(this, result =>
            {
                actor.Stats.TryAdd(Key, result);
                callback(result);
            });
        }
    }
}