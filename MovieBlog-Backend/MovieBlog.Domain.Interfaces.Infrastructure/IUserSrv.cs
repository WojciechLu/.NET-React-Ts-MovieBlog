using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Infrastructure;

public interface IUserSrv
{
    UsersDTO GetAllUsers();
    ResponseDTO EditUser(UserDTO user);
    ResponseDTO DeleteUser(UserDTO user);
}
