using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Domain.Stories
{
    public class TextEvent : LockedByStatEntity
    {
        private string Data { get; }
        public int Tempo { get; private set; }
        private List<Resolver> Resolvers { get; }

        private Dictionary<string, Resolver> ResolversDict { get; }
        private List<string> Keys { get; }

        public TextEvent(
            string data,
            int tempo, 
            List<Resolver> resolvers,
            StatActor statActor,
            string lockedByStat,
            string lockedByStatValue) : base(statActor, lockedByStat, lockedByStatValue)
        {
            Data = data;
            Resolvers = resolvers;
            Tempo = tempo;

            ResolversDict = Resolvers.ToDictionary(resolver => resolver.Key, resolver => resolver);
            Keys = ResolversDict.Select(r => r.Key).ToList();
        }

        public void Resolve(Action<string> callback)
        {
            var responseText = Data;

            ResponseText(responseText, callback);
        }

        private void ResponseText(string responseText, Action<string> callback)
        {
            var itemsProcessed = 0;

            if (!responseText.ContainsAny(Keys, out var found))
            {
                callback(responseText);
                return;
            }

            foreach (var key in found)
            {
                ResolversDict[key].Resolve(response =>
                {
                    ResponseText(response, result =>
                    {
                        responseText = responseText.Replace(key, result);

                        itemsProcessed++;

                        if (itemsProcessed == found.Count)
                        {
                            callback(responseText);
                        }
                    });
                });
            }
        }
    }
}