using System.Collections.Generic;

namespace Domain.Resolvers
{
    public class InputDropdownResolver : InputResolver
    {
        public List<string> Options { get; private set; }
        
        public InputDropdownResolver(string key, string tittle, List<string> options, bool save) : base(key, tittle, save)
        {
            Options = options;
        }
    }
}