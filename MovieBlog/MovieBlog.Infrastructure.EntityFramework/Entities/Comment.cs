namespace MovieBlog.Infrastructure.EntityFramework.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public int AuthorId { get; set; }
    public int? ParentId { get; set; }
    public ICollection<Comment>? Children { get; set; }
}
