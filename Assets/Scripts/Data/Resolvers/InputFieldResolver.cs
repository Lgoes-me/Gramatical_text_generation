namespace Data.Resolvers
{
    [System.Serializable]
    public class InputFieldResolver : InputResolver
    {
        public override Domain.Resolver ToDomain()
        {
            return new Domain.Resolvers.InputFieldResolver(Key, Tittle, Save);
        }
    }
}