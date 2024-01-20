namespace Domain.Resolvers
{
    public abstract class InputResolver : Resolver
    {
        public string Tittle { get; private set; }
        protected bool Save { get; set; }
        
        protected InputResolver(string key, string tittle, bool save) : base(key)
        {
            Tittle = tittle;
            Save = save;
        }
    }
}