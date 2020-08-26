using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void AddCampaign(Category category, Campaign campaign);
    }
}