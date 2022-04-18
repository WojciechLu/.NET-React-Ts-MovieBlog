using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlog.Domain.Common.Models.ModelsDTO.Comment;

public class AddCommentDTO
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public int ReviewId { get; set; }
}
