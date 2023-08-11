using Cinema.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.ViewModels
{
    public class CreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public string Imgurl { get; set; }
        public double Price { get; set; }



        public List<string> ActorsIDs { get; set; } 
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }

        



    }
}
