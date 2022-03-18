using Microsoft.AspNetCore.Mvc;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class MovieController : Controller
    {
        private readonly IMovieSrv movieSrv;
        public MovieController(IMovieSrv movieSrv)
        {
            this.movieSrv = movieSrv;
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            return Ok(movieSrv.GetAllMovies());
        }

        [HttpGet]
        [Route("{title}")]
        public ActionResult GetMovieByTitle([FromRoute] string title)
        {
            return Ok(movieSrv.GetMovieByTitle(title));
        }

        [HttpGet]
        [Route("{category}")]
        public ActionResult GetMoviesByCat([FromRoute] string category)
        {
            return Ok(movieSrv.GetMoviesByCat(category));
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] MovieDTO movie)
        {
            return Ok(movieSrv.AddMovie(movie));
        }

        [HttpPut]
        public ActionResult EditMovie([FromBody] MovieDTO movie)
        {
            return Ok(movieSrv.EditMovie(movie));
        }

        [HttpDelete]
        public ActionResult DeleteMovie([FromBody] MovieDTO movie)
        {
            return Ok(movieSrv.DeleteMovie(movie));
        }
    }
}
