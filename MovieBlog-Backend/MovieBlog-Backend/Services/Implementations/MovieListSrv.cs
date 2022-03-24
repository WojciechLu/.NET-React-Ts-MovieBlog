using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Services.Implementations
{
    public class MovieListSrv : IMovieListSrv
    {
        private readonly ReviewDbContext context;
        public MovieListSrv(ReviewDbContext context)
        {
            this.context = context;
        }

        public ResponseDTO AddMovieToList(int movieId, int listId)
        {
            var list = context.ToWatch.FirstOrDefault(l => l.Id == listId);
            if (list != null)
            {
                var movieToAdd = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (movieToAdd != null)
                {
                    try
                    {
                        if (context.MoviesList.FirstOrDefault(ml => ml.MovieId == movieToAdd.Id && ml.ListId == list.Id) != null)
                        {
                            return new ResponseDTO() { Code = 400, Message = "Movie is already added to list", Status = "Failed" };
                        }
                        else
                        {
                            var newMovieList = new MovieList
                            {
                                List = list,
                                ListId = list.Id,
                                Movie = movieToAdd,
                                MovieId = movieToAdd.Id
                            };
                            if(list.MoviesLists == null)
                            {
                                list.MoviesLists = new List<MovieList>();
                            }
                            list.MoviesLists.Add(newMovieList);
                            if(movieToAdd.MovieLists == null)
                            {
                                movieToAdd.MovieLists = new List<MovieList>();
                            }
                            movieToAdd.MovieLists.Add(newMovieList);
                            context.MoviesList.Add(newMovieList);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                    }
                    return new ResponseDTO { Code = 200, Message = "Successfully added movie to watch list", Status = "Success" };
                }
                else return new ResponseDTO { Code = 400, Message = "Movie with this id doesnt exist", Status = "Failed" };
            }
            else return new ResponseDTO { Code = 400, Message = "List with this owner id doesn't exist", Status = "Failed" };
        }

        public MoviesDTO GetMoviesFromList(int listId)
        {
            var operatingList = context.ToWatch.FirstOrDefault(l => l.Id == listId);
            if (operatingList != null)
            {
                try
                {
                    MoviesDTO movies = new MoviesDTO();
                    movies.moviesList = new List<MovieDTO>();

                    var movieList = operatingList.MoviesLists.ToList();
                    foreach (MovieList movie in movieList)
                    {
                        var movieToRead = context.Movies.FirstOrDefault(m => m.Id == movie.MovieId);
                        movies.moviesList.Add(new MovieDTO { Id = movieToRead.Id, Category = movieToRead.Category, Title = movieToRead.Title, Image = movieToRead.Image });
                    }
                    return movies;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            else return null;
        }

        public ResponseDTO RemoveMovieFromList(int movieId, int listId)
        {
            var movieList = context.MoviesList.FirstOrDefault(ml => ml.MovieId == movieId && ml.ListId == listId);
            var movieToRemove = context.Movies.FirstOrDefault(m => m.Id == movieId);
            var listToWatch = context.ToWatch.FirstOrDefault(l => l.Id == listId);
            if ((movieList != null) && (movieToRemove != null) && (listToWatch != null))
            {
                try
                {
                    movieToRemove.MovieLists.Remove(movieList);
                    listToWatch.MoviesLists.Remove(movieList);
                    context.MoviesList.Remove(movieList);
                    context.SaveChanges();
                    return new ResponseDTO() { Code = 200, Message = "Removed movie from list", Status = "Success" };
                }
                catch (Exception ex)
                {
                    return new ResponseDTO() { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO() { Code = 400, Message = "Not found movielist or movie or list to watch", Status = "Failed" };
        }
    }
}
