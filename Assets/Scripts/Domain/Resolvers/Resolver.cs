using System;

namespace Domain
{
    public abstract class Resolver
    {
        public string Key { get; set; }
        
        protected Resolver(string key)
        {
            Key = key;
        }

        public abstract void Resolve(Action<string> callback);
    }
}