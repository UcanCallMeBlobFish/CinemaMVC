using Cinema.Models;

namespace Cinema.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(

                        new Actor()
                        {
                            Name = "Actor 1",
                            LastName = "Actor Last Name 1",
                            Description = "This is the Bio of the first actor",
                            Imgurl = "http://dotnethow.net/images/actors/actor-1.jpeg"
                            
                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            LastName = "Actor Last Name 2",
                            Description = "This is the Bio of the second actor",
                            Imgurl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            LastName = "Actor Last Name 3",
                            Description = "This is the Bio of the third actor",
                            Imgurl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            LastName = "Actor Last Name 4",
                            Description = "This is the Bio of the fourth actor",
                            Imgurl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            LastName = "Actor Last Name 5",
                            Description = "This is the Bio of the fifth actor",
                            Imgurl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        });
                }
                context.SaveChanges();

                if(!context.CinemaSections.Any())
                {
                    context.CinemaSections.AddRange
                        (

                        new CinemaSection()
                        {
                            SectionName = "Cinema 1",
                            Imgurl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema section"
                        },
                        new CinemaSection()
                        {
                            SectionName = "Cinema 2",
                            Imgurl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second cinema section"
                        },
                        new CinemaSection()
                        {
                            SectionName = "Cinema 3",
                            Imgurl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third cinema section"
                        },
                        new CinemaSection()
                        {
                            SectionName = "Cinema 4",
                            Imgurl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the fourth cinema section"
                        },
                        new CinemaSection()
                        {
                            SectionName = "Cinema 5",
                            Imgurl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the fifth cinema section"
                        }

                        );
                }
                context.SaveChanges();

                if(!context.Producers.Any() ) 
                {
                    context.Producers.AddRange
                        (

                        new Producer()
                        {
                            Name = "Producer 1",
                            LastName = "Producer Last Name 1",
                            Description = "This is the Bio of the first producer",
                            Imgurl = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 2",
                            LastName = "Producer Last Name 2",
                            Description = "This is the Bio of the second producer",
                            Imgurl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 3",
                            LastName = "Producer Last Name 3",
                            Description = "This is the Bio of the third producer",
                            Imgurl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 4",
                            LastName = "Producer Last Name 4",
                            Description = "This is the Bio of the fourth producer",
                            Imgurl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 5",
                            LastName = "Producer Last Name 5",
                            Description = "This is the Bio of the fifth producer",
                            Imgurl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }

                        );
                }
                context.SaveChanges();

                if(!context.Categories.Any())
                {
                    context.Categories.AddRange
                        (
                        
                            new Category()
                            {
                                Name = "Horror"
                            },
                            new Category()
                            {
                                Name = "Comedy"
                            },
                            new Category()
                            {
                                Name = "Porn"
                            }, new Category()
                            {
                                Name = "Horror"
                            },
                            new Category()
                            {
                                Name = "Comedy"
                            },
                            new Category()
                            {
                                Name = "Porn"
                            }, new Category()
                            {
                                Name = "Horror"
                            },
                            new Category()
                            {
                                Name = "Comedy"
                            },
                            new Category()
                            {
                                Name = "Porn"
                            }

                        );
                }
                context.SaveChanges();

               

                var producers= context.Producers.OrderBy(a => a.ProducerId).ToList();


                var categories = context.Categories.ToList();
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange
                        (
                        new Movie()
                        {
                            Title = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = producers[0].ProducerId,
                            CategoryId = categories[0].CategoryId,
                            
                        },
                        new Movie()
                        {
                            Title = "The Shawshank Redemption",
                            Description = "This is The Shawshank Redemption description",
                            Price = 29.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            ProducerId = producers[1].ProducerId,
                            CategoryId = categories[2].CategoryId
                        },
                        new Movie()
                        {
                            Title = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            ProducerId = producers[2].ProducerId,
                            CategoryId = categories[3].CategoryId
                        },
                        new Movie()
                        {
                            Title = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            ProducerId = producers[3].ProducerId,
                            CategoryId = categories[4].CategoryId
                        },
                        new Movie()
                        {
                            Title = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            ProducerId = producers[4].ProducerId,
                            CategoryId = categories[5].CategoryId
                        },
                        new Movie()
                        {
                            Title = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            Imgurl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            ProducerId = producers[4].ProducerId,
                            CategoryId = categories[6].CategoryId
                        }

                        );
                }
                context.SaveChanges();

                var movies = context.Movies.OrderBy(a => a.Title).ToList();

                var actors = context.Actors.ToList();

                if (!context.ActorsMovies.Any())
                {
                    context.ActorsMovies.AddRange
                    (
                        new ActorsMovie() { ActorId = actors[0].ActorId, MovieId = movies[0].MovieId },
                        new ActorsMovie() { ActorId = actors[1].ActorId, MovieId = movies[1].MovieId },
                        new ActorsMovie() { ActorId = actors[2].ActorId, MovieId = movies[2].MovieId },
                        new ActorsMovie() { ActorId = actors[3].ActorId, MovieId = movies[3].MovieId },
                        new ActorsMovie() { ActorId = actors[4].ActorId, MovieId = movies[4].MovieId },
                        new ActorsMovie() { ActorId = actors[4].ActorId, MovieId = movies[5].MovieId }
                    );
                }

                context.SaveChanges();

                var cinemas = context.CinemaSections.ToList();
                if (!context.CinemaMovies.Any())
                {
                    context.CinemaMovies.AddRange
                        (

                         new CinemaMovie
                         {
                             MovieId = movies[0].MovieId,
                             CinemaSectionID = cinemas[0].CinemaSectionId
                         },
                        new CinemaMovie
                        {
                            MovieId = movies[0].MovieId,
                            CinemaSectionID = cinemas[2].CinemaSectionId
                        },
                        new CinemaMovie
                        {
                            MovieId = movies[0].MovieId,
                            CinemaSectionID = cinemas[3].CinemaSectionId
                        },
                        new CinemaMovie
                        {
                            MovieId = movies[2].MovieId,
                            CinemaSectionID = cinemas[2].CinemaSectionId
                        },
                        new CinemaMovie
                        {
                            MovieId = movies[1].MovieId,
                            CinemaSectionID = cinemas[0].CinemaSectionId
                        },
                        new CinemaMovie
                        {
                            MovieId = movies[3].MovieId,
                            CinemaSectionID = cinemas[0].CinemaSectionId
                        },
                        new CinemaMovie
                        {
                            MovieId = movies[4].MovieId,
                            CinemaSectionID = cinemas[0].CinemaSectionId
                        }

                        );
                }
                context.SaveChanges();


            }
        }
    }
}
