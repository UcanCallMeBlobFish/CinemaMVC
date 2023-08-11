using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext _context;

        public ProducerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Producer> GetAllProducers()
        {
            return _context.Producers.ToList();
        }

        public Producer GetProducerDetails(int id)
        {
            var producers = _context.Producers.Where(Producer => Producer.ProducerId == id).FirstOrDefault();
            return producers;
        }

        public Producer EditProducerInformation(Producer Producer)
        {
            var dbactor = _context.Producers.Where(a => a.ProducerId == Producer.ProducerId).FirstOrDefault();

            dbactor.Name = Producer.Name;
            dbactor.Description = Producer.Description;
            dbactor.LastName = Producer.LastName;
            dbactor.Imgurl = Producer.Imgurl;

            return dbactor;
        }

        public void AddProducer(Producer Producer)
        {
            _context.Producers.Add(Producer);
            _context.SaveChanges();
        }

        public void RemoveProducer(int id)
        {
            var remove = _context.Producers.Where(a => a.ProducerId == id).FirstOrDefault();
            _context.Remove(remove);
            _context.SaveChanges();
        }



        public void UpdateProducer(Producer updatedProducer)
        {
            var existingActor = _context.Producers.Where(a => a.ProducerId == updatedProducer.ProducerId).FirstOrDefault();

            existingActor.Name = updatedProducer.Name;
            existingActor.Description = updatedProducer.Description;
            existingActor.LastName = updatedProducer.LastName;
            existingActor.Imgurl = updatedProducer.Imgurl;

            _context.SaveChanges();


        }

       
    }
}
