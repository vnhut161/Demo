using MyUp.Data.Infrastructure;
using MyUp.Model.Models;

namespace MyUp.Data.Repositories
{
    public interface IOrderDetailRepository
    {
    }

    public class OrderDetailRepository : RepositoryBase<Product>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}