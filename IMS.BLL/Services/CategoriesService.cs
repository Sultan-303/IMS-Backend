using IMS.DTO;
using IMS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return _categoriesRepository.GetAllCategoriesAsync();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return _categoriesRepository.GetCategoryByIdAsync(id);
        }

        public Task AddCategoryAsync(Category category)
        {
            return _categoriesRepository.AddCategoryAsync(category);
        }

        public Task UpdateCategoryAsync(Category category)
        {
            return _categoriesRepository.UpdateCategoryAsync(category);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _categoriesRepository.DeleteCategoryAsync(id);
        }
    }
}