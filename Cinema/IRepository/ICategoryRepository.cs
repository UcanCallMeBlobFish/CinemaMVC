using Cinema.Models;

namespace Cinema.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
    }
}