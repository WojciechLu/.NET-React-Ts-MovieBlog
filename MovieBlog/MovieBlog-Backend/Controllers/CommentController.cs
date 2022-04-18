using Microsoft.AspNetCore.Mvc;
using MovieBlog.Domain.Common.Models.ModelsDTO.Comment;
using MovieBlog.Domain.Interfaces.Facades;

namespace MovieBlog_Backend.Controllers;

[Route("[controller]/[action]")]
public class CommentController : Controller
{
    private readonly ICommentFcd commentFcd;

    public CommentController(ICommentFcd commentFcd)
    {
        this.commentFcd = commentFcd;
    }

    [HttpGet]
    [Route("{reviewId}")]
    public ActionResult GetAllCommentByReview([FromRoute] int reviewId)
    {
        return Ok(commentFcd.GetAllCommentByReview(reviewId));
    }

    [HttpPost]
    public ActionResult AddCommentToReview([FromBody] AddCommentDTO addComment)
    {
        return Ok(commentFcd.AddCommentToReview(addComment));
    }

    [HttpPost]
    public ActionResult AddReply([FromBody] AddReplyDTO addComment)
    {
        return Ok(commentFcd.AddCommentToReview(addComment));
    }
}
