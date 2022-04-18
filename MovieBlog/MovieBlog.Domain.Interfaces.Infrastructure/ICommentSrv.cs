using MovieBlog.Domain.Common.Models.ModelsDTO.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlog.Domain.Interfaces.Infrastructure;

public interface ICommentSrv
{
    CommentDTO AddCommentToReview(AddCommentDTO addComment);
    CommentDTO AddCommentToReview(AddReplyDTO addComment);
    CommentDTO GetAllCommentByReview(int reviewId);
}
