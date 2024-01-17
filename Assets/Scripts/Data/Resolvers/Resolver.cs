using System;
using UnityEngine;

namespace Data.Resolvers
{
    [Serializable]
    public abstract class Resolver : IComparable<Resolver>
    {
        [field: SerializeField]
        public string Key { get; set; }
        
        public abstract Domain.Resolver ToDomain();

        public int CompareTo(Resolver other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Key, other.Key, StringComparison.Ordinal);
        }
    }
}