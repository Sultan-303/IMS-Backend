using IMS.DTO;

namespace IMS.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}