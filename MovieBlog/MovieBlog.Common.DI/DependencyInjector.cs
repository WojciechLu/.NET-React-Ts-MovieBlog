using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieBlog.Domain.Facades;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;
using MovieBlog.Infrastructure.EntityFramework;
using MovieBlog.Infrastructure.EntityFramework.Entities;

namespace MovieBlog.Domain.DI;

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
        serviceCollection.AddScoped<IUserFcd, UserFcd>();
        serviceCollection.AddScoped<IMovieFcd, MovieFcd>();
        serviceCollection.AddScoped<IMovieListFcd, MovieListFcd>();
        serviceCollection.AddScoped<IReviewFcd, ReviewFcd>();
    }
}