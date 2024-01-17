using System.Collections.Generic;

namespace Domain
{
    public class Actor
    {
        public Dictionary<string, string> Stats { get; set; }

        public Actor()
        {
            Stats = new Dictionary<string, string>();
        }
    }
}