using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyUp.Data.Infrastructure;
using MyUp.Data.Repositories;
using MyUp.Model.Models;
using MyUp.Service;
using System.Collections.Generic;

namespace MyUp.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _postCategoryRepositoryMock;
        private Mock<IUnitOfWork> _iUnitOfWorkMock;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _postCategoryList;

        [TestInitialize]
        public void Initialize()
        {
            _postCategoryRepositoryMock = new Mock<IPostCategoryRepository>();
            _iUnitOfWorkMock = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_postCategoryRepositoryMock.Object, _iUnitOfWorkMock.Object);
            _postCategoryList = new List<PostCategory>()
            {
                new PostCategory{Id = 1,Name = "DM1",Status = true},
                new PostCategory{Id = 1,Name = "DM1",Status = true},
                new PostCategory{Id = 1,Name = "DM1",Status = true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            _postCategoryRepositoryMock.Setup(x => x.GetAll(null)).Returns(_postCategoryList);
            var result = _postCategoryService.GetAllPostCategories() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            var newPostCategory = new PostCategory
            {
                Name = "Test",
                Alias = "test",
                Status = true
            };
            _postCategoryRepositoryMock.Setup(x => x.Add(newPostCategory)).Returns((PostCategory p) => { p.Id = 1; return p; });
            var result=_postCategoryService.Add(newPostCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Id);
        }
    }
}