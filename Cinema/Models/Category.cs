using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public List<Movie> Movies { get; set; } //nav prop
    }
}