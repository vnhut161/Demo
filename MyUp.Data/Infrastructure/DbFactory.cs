namespace MyUp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EntitiesDbContext _entitiesDbContext;

        public EntitiesDbContext Init()
        {
            return _entitiesDbContext ?? (_entitiesDbContext = new EntitiesDbContext());
        }

        protected override void DisposeCore()
        {
            _entitiesDbContext?.Dispose();
        }
    }
}