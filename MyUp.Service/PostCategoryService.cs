﻿using MyUp.Data.Infrastructure;
using MyUp.Data.Repositories;
using MyUp.Model.Models;
using System.Collections.Generic;

namespace MyUp.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory DeleteById(int id);

        void SaveChanges();

        IEnumerable<PostCategory> GetAllPostCategories();

        IEnumerable<PostCategory> GetAllPostCategoriesById(int id);

        PostCategory GetPostById(int id);
    }

    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }

        public PostCategory DeleteById(int id)
        {
            return _postCategoryRepository.DeleteById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PostCategory> GetAllPostCategories()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllPostCategoriesById(int id)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentId == id);
        }

        public PostCategory GetPostById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }
    }
}