using MovieBlog_Backend.Models;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IUserSrv
    {
        User GetAllUsers();
        ResponseDTO EditUser(User user);
        ResponseDTO DeleteUser(User user);
    }
}
