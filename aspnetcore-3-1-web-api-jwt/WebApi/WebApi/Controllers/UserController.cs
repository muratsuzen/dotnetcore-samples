using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public ActionResult Authenticate([FromBody] AuthModel authModel)
        {
            var user = _userService.Authenticate(authModel.UserName,authModel.Password);

            if (user == null)
                return BadRequest(new { message = "Kullanıcı adı yada şifre yanlış" });

            return Ok(user);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}