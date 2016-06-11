namespace MyUp.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private EntitiesDbContext _entitiesDbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private EntitiesDbContext EntitiesDbContext => _entitiesDbContext ?? (_entitiesDbContext = _dbFactory.Init());

        public void Commit()
        {
            EntitiesDbContext.SaveChanges();
        }
    }
}