using Cinema.Models;

namespace Cinema.ViewModels
{
    public class RoleVM
    {
        public string Name { get; set; }
        public string id { get; set; }

        public List<User> users { get; set; }
    }
}
