namespace Cinema.Models
{
    public class CinemaMovie
    {
        public int CinemaMovieId { get; set; }


        //Nav
        public int MovieId { get; set;}
        public Movie Movie { get; set;}


        public int CinemaSectionID { get; set; }
        public CinemaSection CinemaSection { get; set; }



    }
}
