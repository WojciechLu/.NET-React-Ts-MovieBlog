namespace MovieBlog.Infrastructure.EntityFramework.Entities;

public class ListToWatch
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public IList<MovieList> MoviesLists { get; set; }
    public User Owner { get; set; }
}
