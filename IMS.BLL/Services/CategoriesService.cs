using IMS.Common.Models;
using IMS.Common.Entities;
using IMS.Interfaces.Services;
using IMS.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();
            return categories.Select(ToCategoryModel);
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(id);
            return category == null ? null : ToCategoryModel(category);
        }

        public async Task AddCategoryAsync(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                throw new ArgumentNullException(nameof(categoryModel), "Category is null.");
            }

            var category = ToCategoryEntity(categoryModel);
            await _categoriesRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                throw new ArgumentNullException(nameof(categoryModel), "Category is null.");
            }

            var category = ToCategoryEntity(categoryModel);
            await _categoriesRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return; // Do nothing if the category is not found
            }

            await _categoriesRepository.DeleteCategoryAsync(id);
        }

        private CategoryModel ToCategoryModel(Category category)
        {
            return new CategoryModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }

        private Category ToCategoryEntity(CategoryModel categoryModel)
        {
            return new Category
            {
                CategoryID = categoryModel.CategoryID,
                CategoryName = categoryModel.CategoryName
            };
        }
    }
}