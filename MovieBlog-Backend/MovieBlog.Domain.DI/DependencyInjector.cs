using Microsoft.EntityFrameworkCore;
using MovieBlog_Backend.Data;
using MovieBlog_Backend.Services.Implementations;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Services
{
    public static class DependencyInjector
    {
        public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContext<ReviewDbContext>(x => x.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IUserSrv, UserSrv>();
            serviceCollection.AddScoped<IMovieSrv, MovieSrv>();
            serviceCollection.AddScoped<IMovieListSrv, MovieListSrv>();
            serviceCollection.AddScoped<IReviewSrv, ReviewSrv>();
        }
    }}