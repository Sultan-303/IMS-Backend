using IMS.DTO;
using IMS.Interfaces;

namespace IMS.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}