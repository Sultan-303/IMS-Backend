using IMS.BLL.DTOs.Category;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Interfaces.Services;

namespace IMS.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            return await _categoriesRepository.GetAllCategoriesAsync();
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            return await _categoriesRepository.GetCategoryByIdAsync(id);
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                throw new ArgumentNullException(nameof(categoryDto));

            await _categoriesRepository.AddCategoryAsync(categoryDto);
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                throw new ArgumentNullException(nameof(categoryDto));

            await _categoriesRepository.UpdateCategoryAsync(categoryDto);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoriesRepository.DeleteCategoryAsync(id);
        }
    }
}