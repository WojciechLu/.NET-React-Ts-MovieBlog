using Microsoft.AspNetCore.Mvc;
using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Implementations;
using MovieBlog_Backend.Services.Interfaces;

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
