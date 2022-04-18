using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlog.Domain.Common.Models.ModelsDTO.Comment;

public class AddReplyDTO
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public int CommentId { get; set; }
}
}
