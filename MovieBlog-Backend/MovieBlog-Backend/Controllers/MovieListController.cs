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
        [Route("")]
        public ActionResult AddMovieToList([FromBody] AddMovieListDTO addMovieList)
        {
            return Ok(movieListSrv.AddMovieToList(addMovieList));
        }

        [HttpDelete]
        [Route("")]
        public ActionResult RemoveMovieFromList([FromBody] AddMovieListDTO addMovieList)
        {
            return Ok(movieListSrv.RemoveMovieFromList(addMovieList));
        }

        [HttpGet]
        [Route("{listId}")]
        public ActionResult GetMoviesFromList([FromRoute] int listId)
        {
            return Ok(movieListSrv.GetMoviesFromList(listId));
        }

        [HttpGet]
        /*[Route("{listId}")]*/
        [Route("")]
        public ActionResult GetMoviesFromListByCategory([FromQuery] MovieListCategoryDTO movieCategory)
        {
            return Ok(movieListSrv.GetMoviesFromListByCategory(movieCategory));
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetMovieList()
        {
            return Ok(movieListSrv.GetMovieLists());
        }
    }
}
