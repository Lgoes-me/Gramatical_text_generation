using System;
using System.Collections.Generic;

namespace Domain.Resolvers
{
    public class OptionsResolver : Resolver
    {
        private List<string> Options { get; set; }

        public OptionsResolver(string key, List<string> options) : base(key)
        {
            Options = options;
        }

        public override void Resolve(Action<string> callback)
        {
            var value = UnityEngine.Random.Range(0, Options.Count);
            callback(Options[value]);
        }
    }
}