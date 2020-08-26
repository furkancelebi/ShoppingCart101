using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<string, Category>, ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category>();
        }
    }
}