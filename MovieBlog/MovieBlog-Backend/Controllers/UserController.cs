using Microsoft.AspNetCore.Mvc;
using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController: Controller
    {
        private readonly IUserSrv userSrv;
        public UserController(IUserSrv userSrv)
        {
            this.userSrv = userSrv;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(userSrv.GetAllUsers());
        }

        [HttpPut]
        public ActionResult EditUser([FromBody] UserDTO userToEdit)
        {
            return Ok(userSrv.EditUser(userToEdit));
        }

        [HttpDelete]
        public ActionResult DeleteUser([FromBody] UserDTO userToDelete)
        {
            return Ok(userSrv.DeleteUser(userToDelete));
        }

    }
}
