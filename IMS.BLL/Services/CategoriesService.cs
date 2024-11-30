using IMS.Interfaces;
using IMS.DTO;

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

    }
}