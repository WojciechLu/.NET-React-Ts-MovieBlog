using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlog.Infrastructure.EntityFramework.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public Comment ParentComment { get; set; }
    public ICollection<Comment> Children { get; set; }
}
