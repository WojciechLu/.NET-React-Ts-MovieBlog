using MovieBlog.Infrastructure.EntityFramework;

namespace MovieBlog.Infrastructure.EntityFramework
{
    public class User : IdentityUser
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
