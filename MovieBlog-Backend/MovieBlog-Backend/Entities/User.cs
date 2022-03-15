namespace MovieBlog_Backend.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Review> Reviews { get; set; }
        public ListToWatch ToWatch { get; set; }

    }
}
