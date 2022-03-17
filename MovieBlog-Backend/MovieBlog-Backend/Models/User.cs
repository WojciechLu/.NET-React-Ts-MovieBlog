using Microsoft.AspNetCore.Identity;
using MovieBlog_Backend.Entities;

namespace MovieBlog_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdListToWatch { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public IList<Review> Reviews { get; set; }
        public ListToWatch ToWatch { get; set; }
    }
}
