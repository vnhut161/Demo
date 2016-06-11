using MyUp.Data.Infrastructure;
using MyUp.Model.Models;

namespace MyUp.Data.Repositories
{
    public interface IFooterRepository
    {
    }

    public class FooterRepository : RepositoryBase<Product>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}