using MovieBlog.Domain.Common.Models.ModelsDTO.Comment;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlog.Domain.Facades;

public class CommentFcd : ICommentFcd
{
    private readonly ICommentSrv commentSrv;
    public CommentFcd(ICommentSrv commentSrv)
    {
        this.commentSrv = commentSrv;
    }
    public CommentDTO AddCommentToReview(AddCommentDTO addComment)
    {
        return commentSrv.AddCommentToReview(addComment);
    }

    public CommentDTO AddCommentToReview(AddReplyDTO addComment)
    {
        return commentSrv.AddCommentToReview(addComment);
    }

    public CommentDTO GetAllCommentByReview(int reviewId)
    {
        return commentSrv.GetAllCommentByReview(reviewId);
    }
}
