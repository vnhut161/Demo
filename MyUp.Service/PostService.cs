using MyUp.Data.Infrastructure;
using MyUp.Data.Repositories;
using MyUp.Model.Models;
using System.Collections.Generic;

namespace MyUp.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void DeleteById(int id);

        void SaveChanges();

        IEnumerable<Post> GetAllPosts();

        IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalRow);

        Post GetPostById(int id);

        IEnumerable<Post> GetAllByTagPaging(int page, int pagesize, out int totalRow);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void DeleteById(int id)
        {
            _postRepository.DeleteById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAll(new[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pagesize);
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetAllByTagPaging(int page, int pagesize, out int totalRow)
        {
            //TODO: select  all post by tag
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pagesize);
        }
    }
}