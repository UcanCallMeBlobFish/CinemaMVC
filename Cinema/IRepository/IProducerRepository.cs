using Cinema.Models;

namespace Cinema.IRepository
{
    public interface IProducerRepository
    {
        void AddProducer(Producer Producer);
        Producer EditProducerInformation(Producer Producer);
        List<Producer> GetAllProducers();
        Producer GetProducerDetails(int id);
        void RemoveProducer(int id);
        void UpdateProducer(Producer updatedProducer);
    }
}