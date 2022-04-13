using Microsoft.AspNetCore.Mvc;
using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;

namespace MovieBlog_Backend.Controllers;

[Route("[controller]/[action]")]
public class MovieListController: Controller
{
    private readonly IMovieListFcd movieListFcd;
    public MovieListController(IMovieListFcd movieListFcd)
    {
        this.movieListFcd = movieListFcd;
    }

    [HttpPost]
    [Route("")]
    public ActionResult AddMovieToList([FromBody] AddMovieListDTO addMovieList)
    {
        return Ok(movieListFcd.AddMovieToList(addMovieList));
    }

    [HttpDelete]
    [Route("")]
    public ActionResult RemoveMovieFromList([FromBody] AddMovieListDTO addMovieList)
    {
        return Ok(movieListFcd.RemoveMovieFromList(addMovieList));
    }

    [HttpGet]
    [Route("{listId}")]
    public ActionResult GetMoviesFromList([FromRoute] int listId)
    {
        return Ok(movieListFcd.GetMoviesFromList(listId));
    }

    [HttpGet]
    /*[Route("{listId}")]*/
    [Route("")]
    public ActionResult GetMoviesFromListByCategory([FromQuery] MovieListCategoryDTO movieCategory)
    {
        return Ok(movieListFcd.GetMoviesFromListByCategory(movieCategory));
    }

    [HttpGet]
    [Route("")]
    public ActionResult GetMovieList()
    {
        return Ok(movieListFcd.GetMovieLists());
    }
}
