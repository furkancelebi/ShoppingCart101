using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repositories;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetList();
        }

        public void AddCategory(Category category)
        {
            var categories = GetCategories();

            if (categories.Find(x => x.Id == category.Id) != null)
            {
                throw new Exception("Category already exists!");
            }

            _categoryRepository.Add(category.Id, category);
        }

        public void AddCampaign(Category category, Campaign campaign)
        {
            category.AddCampaign(campaign);

            _categoryRepository.Update(category.Id, category);
        }
    }
}