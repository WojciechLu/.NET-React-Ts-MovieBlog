using Microsoft.AspNetCore.Mvc;
using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;

namespace MovieBlog_Backend.Controllers;

[Route("[controller]/[action]")]
public class MovieController : Controller
{
    private readonly IMovieFcd movieFcd;
    public MovieController(IMovieFcd movieFcd)
    {
        this.movieFcd = movieFcd;
    }

    [HttpGet]
    public ActionResult GetAllMovies()
    {
        return Ok(movieFcd.GetAllMovies());
    }

    [HttpGet]
    [Route("{title}")]
    public ActionResult GetMovieByTitle([FromRoute] string title)
    {
        return Ok(movieFcd.GetMovieByTitle(title));
    }

    [HttpGet]
    [Route("{category}")]
    public ActionResult GetMoviesByCat([FromRoute] string category)
    {
        return Ok(movieFcd.GetMoviesByCat(category));
    }

    [HttpPost]
    public ActionResult AddMovie([FromBody] MovieDTO movie)
    {
        return Ok(movieFcd.AddMovie(movie));
    }

    [HttpPut]
    public ActionResult EditMovie([FromBody] MovieDTO movie)
    {
        return Ok(movieFcd.EditMovie(movie));
    }

    [HttpDelete]
    public ActionResult DeleteMovie([FromBody] MovieDTO movie)
    {
        return Ok(movieFcd.DeleteMovie(movie));
    }
}
