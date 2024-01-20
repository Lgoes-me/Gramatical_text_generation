using System;
using System.Collections.Generic;
using System.Linq;
using Debug;
using Domain.Stories;

namespace Domain.Resolvers
{
    public class InputDropdownResolver : InputResolver
    {
        public StatActor StatActor { get; private set; }
        public List<StatOption> Options { get; private set; }
        
        public InputDropdownResolver(
            string key, 
            string tittle,
            StatActor statActor, 
            List<StatOption> options,
            bool save) : base(key, tittle, save)
        {
            StatActor = statActor;
            Options = options;
        }
        public override void Resolve(Action<string> callback)
        {
            if (!Save)
            {
                GameplayScene.Instance.OpenModal(this, statOption =>
                {
                    callback.Invoke(statOption.OptionText);
                });
                return;
            }
            
            var actor = StatActor.ToActor();

            if (actor.Stats.TryGetValue(Key, out var stat))
            {
                callback.Invoke(Options.First(o => o.StatValue == stat).OptionText);
                return;
            }

            GameplayScene.Instance.OpenModal(this, statOption =>
            {
                actor.Stats.TryAdd(Key, statOption.StatValue);
                callback.Invoke(statOption.OptionText);
            });
        }
    }
}