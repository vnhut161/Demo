using MyUp.Data.Infrastructure;
using MyUp.Model.Models;

namespace MyUp.Data.Repositories
{
    public interface ISlideRepository
    {
    }

    public class SlideRepository : RepositoryBase<Product>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}