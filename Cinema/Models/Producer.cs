using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Producer
    {

        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Imgurl { get; set; }

        public List<Movie> Movies { get; set; } // Nav prop
    }
}
