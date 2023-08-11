namespace Cinema.Models
{
    public class ActorsMovie
    {
        public int ActorsMovieId { get; set; }

        //Nav

        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set;}
    }
}
