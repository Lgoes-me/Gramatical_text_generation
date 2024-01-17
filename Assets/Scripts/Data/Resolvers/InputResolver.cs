using UnityEngine;

namespace Data.Resolvers
{
    [System.Serializable]
    public abstract class InputResolver : Resolver
    {
        [field: SerializeField]
        [field: TextAreaAttribute]
        protected string Tittle { get; private set; }

        [field: SerializeField]
        protected bool Save { get; private set; }
    }
}