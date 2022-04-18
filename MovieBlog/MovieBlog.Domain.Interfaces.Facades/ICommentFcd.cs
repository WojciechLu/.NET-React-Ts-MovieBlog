using MovieBlog.Domain.Common.Models.ModelsDTO.Comment;

namespace MovieBlog.Domain.Interfaces.Facades;

public interface ICommentFcd
{
    CommentDTO GetAllCommentByReview(int reviewId);
    CommentDTO AddCommentToReview(AddCommentDTO addComment);
    CommentDTO AddCommentToReview(AddReplyDTO addComment);
}
