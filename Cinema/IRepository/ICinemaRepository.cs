using Cinema.Models;

namespace Cinema.IRepository
{
    public interface ICinemaRepository
    {
        List<CinemaSection> GetAllCinemas();
    }
}