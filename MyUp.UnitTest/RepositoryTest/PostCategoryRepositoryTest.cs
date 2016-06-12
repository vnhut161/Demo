using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyUp.Data.Infrastructure;
using MyUp.Data.Repositories;
using MyUp.Model.Models;

namespace MyUp.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _postCategoryRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            var postCategory = new PostCategory
            {
                Name = "Test postCategory",
                Alias = "Test-postCategory",
                Status = true
            };
            var result = _postCategoryRepository.Add(postCategory);
            _unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Id);
        }
        [TestMethod]
        public void PostCategory_Repository_Update()
        {
            var postCategory = new PostCategory
            {
                Name = "Test postCategory",
                Alias = "Test-postCategory",
                Status = true
            };
            var result = _postCategoryRepository.Add(postCategory);
            _unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var result = _postCategoryRepository.GetAll().ToList();
            Assert.AreEqual(3, result.Count);
        }
    }
}