using IMS.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsync(int id);
    }
}