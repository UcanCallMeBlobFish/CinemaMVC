using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }
        public string Imgurl { get; set; }

        //Nav M:M 

        [InverseProperty("Actor")]
        public List<ActorsMovie> ActorsMovies { get; set; }

    }
}
