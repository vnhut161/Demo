using MyUp.Data.Infrastructure;
using MyUp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyUp.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllPostsByTag(string tag, int index, int size, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllPostsByTag(string tag, int index, int size, out int totalRow)
        {
            var result = from p in EntitiesContext.Posts
                         join pt in EntitiesContext.PostTags
                             on p.Id equals pt.PostId
                         where pt.TagId == tag && p.Status
                         orderby p.CreatedDate descending
                         select p;
            totalRow = result.Count();
            result = result.Skip((index - 1) * size).Take(size);
            return result;
        }
    }
}