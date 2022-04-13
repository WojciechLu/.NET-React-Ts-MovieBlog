using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Facades;

public interface IUserFcd
{
    UsersDTO GetAllUsers();
    ResponseDTO EditUser(UserDTO user);
    ResponseDTO DeleteUser(UserDTO user);
}
