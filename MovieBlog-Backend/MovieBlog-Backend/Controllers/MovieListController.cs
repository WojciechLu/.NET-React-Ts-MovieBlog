using Microsoft.AspNetCore.Mvc;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class MovieListController: Controller
    {
        private readonly IMovieListSrv movieListSrv;
        public MovieListController(IMovieListSrv movieListSrv)
        {
            this.movieListSrv = movieListSrv;
        }

        [HttpPost]
        [Route("{movieId}/{listId}")]
        public ActionResult AddMovieToList([FromBody] int movieId,[FromRoute] int listId)
        {
            return Ok(movieListSrv.AddMovieToList(movieId, listId));
        }

        [HttpDelete]
        [Route("{movieId}/{listId}")]
        public ActionResult RemoveMovieFromList([FromBody] int movieId,[FromRoute] int listId)
        {
            return Ok(movieListSrv.RemoveMovieFromList(movieId, listId));
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult GetMoviesFromList([FromRoute] int userId)
        {
            return Ok(movieListSrv.GetMoviesFromList(userId));
        }
    }
}
