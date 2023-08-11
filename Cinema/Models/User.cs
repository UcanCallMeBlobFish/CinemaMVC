using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class User:IdentityUser
    {
   
        public string Name { get; set; }

       
        public string Lastname { get; set; }

    }
}
