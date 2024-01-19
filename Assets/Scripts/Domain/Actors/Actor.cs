using System.Collections.Generic;

namespace Domain.Actors
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