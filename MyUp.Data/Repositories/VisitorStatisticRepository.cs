using MyUp.Data.Infrastructure;
using MyUp.Model.Models;

namespace MyUp.Data.Repositories
{
    public interface IVisitorStatisticRepository
    {
    }

    public class VisitorStatisticRepository : RepositoryBase<Product>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}