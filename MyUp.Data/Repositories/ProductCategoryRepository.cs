using MyUp.Data.Infrastructure;
using MyUp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyUp.Data.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductCategoriesByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<ProductCategory> GetProductCategoriesByAlias(string alias)
        {
            return EntitiesContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}