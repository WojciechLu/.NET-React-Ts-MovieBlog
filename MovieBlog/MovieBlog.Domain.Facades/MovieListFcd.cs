using Microsoft.EntityFrameworkCore;
using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog.Domain.Facades;

public class MovieListFcd : IMovieListFcd
{
    private readonly IMovieListSrv movieListSrv;
    public MovieListFcd(IMovieListSrv movieListSrv)
    {
        this.movieListSrv = movieListSrv;
    }
    public ResponseDTO AddMovieToList(AddMovieListDTO addMovieList)
    {
        return movieListSrv.AddMovieToList(addMovieList);
    }

    public MovieListsDTO GetMovieLists()
    {
        return movieListSrv.GetMovieLists();
    }

    public MoviesDTO GetMoviesFromList(int listId)
    {
        return movieListSrv.GetMoviesFromList(listId);
    }

    public MoviesDTO GetMoviesFromListByCategory(MovieListCategoryDTO movieCategory)
    {
        return movieListSrv.GetMoviesFromListByCategory(movieCategory);
    }

    public ResponseDTO RemoveMovieFromList(AddMovieListDTO addMovieList)
    {
        return movieListSrv.RemoveMovieFromList(addMovieList);
    }
}
