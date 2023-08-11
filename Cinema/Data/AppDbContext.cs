using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // For IdentityDbContext<IdentityUser>
using Microsoft.EntityFrameworkCore; // For DbContext and other Entity Framework Core classes
using Cinema.Models; // For Movie, Actor, CinemaSection, Producer, Category, ActorsMovie, CinemaMovie, and other model classes
using Microsoft.AspNetCore.Identity;

namespace Cinema.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }    
        public DbSet<Actor> Actors { get; set; }    
        public DbSet<CinemaSection> CinemaSections { get; set; }    
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        //Joint Tables
        public DbSet<ActorsMovie> ActorsMovies { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get;set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //For CinemaMovie M:M
            modelBuilder.Entity<CinemaMovie>()
                .HasOne(c => c.CinemaSection)
                .WithMany(cm => cm.CinemaMovies)
                .HasForeignKey(c => c.CinemaSectionID);

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(m => m.Movie)
                .WithMany(cm => cm.CinemaMovies)
                .HasForeignKey(M => M.MovieId);

        


            modelBuilder.Entity<ActorsMovie>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.ActorsMovies)
                .HasForeignKey(af => af.ActorId);

            modelBuilder.Entity<ActorsMovie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.ActorsMovies)
                .HasForeignKey(fm => fm.MovieId);


            //validations
            modelBuilder.Entity<Actor>()
                .HasKey(a => a.ActorId);

            modelBuilder.Entity<Actor>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


            modelBuilder.Entity<Actor>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Actor>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Actor>()
                .Property(a => a.Imgurl).IsRequired().HasMaxLength(500);

            //Category
            modelBuilder.Entity<Category>()
               .HasKey(a => a.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            //Movie
            modelBuilder.Entity<Movie>()
                .HasKey(a => a.MovieId);

            modelBuilder.Entity<Movie>()
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(a => a.Imgurl)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(a => a.Price)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(a => a.Imgurl)
                .HasMaxLength(500);



            //Producer

            modelBuilder.Entity<Producer>()
               .HasKey(a => a.ProducerId);

            modelBuilder.Entity<Producer>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


            modelBuilder.Entity<Producer>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Producer>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(500);





        }


    }
}
