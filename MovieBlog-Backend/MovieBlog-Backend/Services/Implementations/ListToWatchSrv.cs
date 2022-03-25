using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Services.Implementations
{
    public class ListToWatchSrv : IListToWatchSrv
    {
        private readonly ReviewDbContext context;
        public ListToWatchSrv(ReviewDbContext context)
        {
            this.context = context;
        }

        public MoviesDTO GetMovies(int userId)
        {
            var result = context.ToWatch.FirstOrDefault(l => l.OwnerId == userId);
            if(result == null)
            {
                return new MoviesDTO();
            }
            else
            {
                try
                {
                    MoviesDTO movies = new MoviesDTO();
                    movies.moviesList = new List<MovieDTO>();

                    var listResult = result.MoviesLists.ToList();
                    foreach(var movie in listResult)
                    {
                        var newMovie = context.Movies.FirstOrDefault(m => m.Id == movie.MovieId);
                        if(newMovie != null)
                        {
                            var i = new MovieDTO { Id = newMovie.Id, Category = newMovie.Category, Title = newMovie.Title, Image = newMovie.Image };
                            movies.moviesList.Add(i);
                        }
                    }
                    return movies;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public MoviesDTO GetMoviesByCategory(int userId, string category)
        {
            var result = context.ToWatch.FirstOrDefault(l => l.OwnerId == userId);
            if (result == null)
            {
                return new MoviesDTO();
            }
            else
            {
                /*try
                {
                    var movieList = result.Movies.ToList();

                    MoviesDTO movies = new MoviesDTO();
                    movies.moviesList = new List<MovieDTO>();

                    foreach (Movie movie in movieList)
                    {
                        if (movie.Category.ToLower() == category.ToLower())
                        {
                            var i = new MovieDTO { Id = movie.Id, Title = movie.Title, Category = movie.Category, Image = movie.Image };
                            movies.moviesList.Add(i);
                        }
                    }
                    return movies;
                }
                catch(Exception ex)
                {
                    return null;
                }*/
                return null;
            }
        }

        public ResponseDTO RemoveMovie(int userId, string title)
        {
            var result = context.ToWatch.FirstOrDefault(l => l.OwnerId == userId);
            if (result == null)
            {
                return new ResponseDTO { Code = 400, Message = "Not found list to watch", Status = "Failed" };
            }
            else
            {
                /*var movieToRemove = result.Movies.FirstOrDefault(m => m.Title == title);

                try
                {
                    result.Movies.Remove(movieToRemove);
                    context.SaveChanges();
                    return new ResponseDTO { Code = 200, Message = "Removed movie from list", Status = "Success" };
                }
                catch(Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }*/
                return new ResponseDTO { Code = 400, Message = "Failed", Status = "Failed" };
            }
        }

        public ListsToWatchDTO GetAllLists()
        {
            var result = context.ToWatch.ToList();
            ListsToWatchDTO lists = new ListsToWatchDTO();
            lists.listToWatch = new List<ListToWatchDTO>();

            foreach(ListToWatch list in result)
            {
                var listDTO = new ListToWatchDTO { Id = list.Id, MoviesList = list.MoviesLists, OwnerId = list.OwnerId };
                lists.listToWatch.Add(listDTO);
            }
            return lists;
        }
    }
}
