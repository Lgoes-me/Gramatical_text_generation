using System.Collections.Generic;

namespace Domain.Actors
{
    public class World : Actor
    {
        public List<Actor> Actors { get; set; } 
        public Actor Player { get; set; }

        public World() : base()
        {
            Actors = new List<Actor>();
            Player = new Actor();
        }
    }
}