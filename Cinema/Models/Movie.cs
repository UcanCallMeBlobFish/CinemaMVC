using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public string Imgurl { get; set; }
        public double Price { get; set; }

        public List<CinemaSection> Cinema { get; set; } // M:M
        public List<Actor> Actors { get; set; } // M:M


        //Nav Properties:
        public int CategoryId { get; set; }
        public Category Category { get; set; }  // 1:m Category:Movie



        public int ProducerId { get; set; }
        public Producer Producer { get; set; } // Nav prop 1:m (Producer:Movie)

        //M:M

        public List<CinemaMovie> CinemaMovies { get; set; }
        
        
        [InverseProperty("Movie")]
        public List<ActorsMovie> ActorsMovies { get; set; }





    }
}
