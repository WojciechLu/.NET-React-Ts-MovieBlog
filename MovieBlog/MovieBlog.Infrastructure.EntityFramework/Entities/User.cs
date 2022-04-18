namespace MovieBlog.Infrastructure.EntityFramework.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int IdListToWatch { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ListToWatch ToWatch { get; set; }
    }
}
