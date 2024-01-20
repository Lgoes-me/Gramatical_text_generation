using System;
using System.Collections.Generic;
using System.Linq;
using Debug;
using UnityEngine;

namespace Domain.Resolvers
{
    public class StatResolver : Resolver
    {
        private string Stat { get; set; }
        private List<StatOption> Options { get; set; }
        
        public StatResolver(string key, string stat, List<StatOption> options) : base(key)
        {
            Stat = stat;
            Options = options;
        }

        public override void Resolve(Action<string> callback)
        {
            var actor = GameplayScene.Instance.World.Player;

            if (actor.Stats.TryGetValue(Stat, out var stat))
            {
                var result = Options.FirstOrDefault(o => o.StatValue == stat);

                if (result != null)
                {
                    callback(result.OptionText);
                    return;
                }
            }
            
            var defaultOption = Options.First(o => string.IsNullOrWhiteSpace(o.StatValue));
            callback(defaultOption.OptionText);
        }
    }

    [Serializable]
    public class StatOption
    {
        [field: SerializeField]
        public string StatValue { get; set; }
        
        [field: SerializeField]
        public string OptionText { get; set; }
    }
}