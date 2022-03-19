using Microsoft.AspNetCore.Mvc;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class ListToWatchController: Controller
    {
        private readonly IListToWatchSrv listToWatchSrv;
        public ListToWatchController(IListToWatchSrv listToWatchSrv)
        {
            this.listToWatchSrv = listToWatchSrv;
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult GetMovies([FromRoute] int userId)
        {
            return Ok(listToWatchSrv.GetMovies(userId));
        }

        [HttpPut]
        [Route("{userId}/{title}")]
        public ActionResult RemoveMovie(int userId, string title)
        {
            return Ok(listToWatchSrv.RemoveMovie(userId, title));
        }

        [HttpGet]
        [Route("{userId}/{category}")]
        public ActionResult GetMoviesByCategory(int userId, string category)
        {
            return Ok(listToWatchSrv.GetMoviesByCategory(userId, category));
        }
    }
}
