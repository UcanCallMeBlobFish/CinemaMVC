using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class CinemaSection
    {
        public int CinemaSectionId { get; set; }

      
        public string SectionName { get; set; }
        public string Description { get; set; }
        public string Imgurl { get; set; }


        //Nav M:M
        public List<CinemaMovie> CinemaMovies { get; set; }


    }
}