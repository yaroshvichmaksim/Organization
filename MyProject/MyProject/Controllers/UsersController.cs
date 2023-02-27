using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyProject.Model;


namespace MyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {

        private UserContext userContext;

        public UsersController(UserContext appContext)
        {
            
            userContext = appContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            if (Request.Cookies["session_id"] != null)
                return Ok(userContext.Users.ToList());

            return Ok();
        }

        // Login 
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Users loguser)
        {
            if (loguser == null)
                return BadRequest();

            var user = userContext.Users.SingleOrDefault(u =>
                u.Email == loguser.Email &&
                u.Password == loguser.Password);

            if (user == null)
                return NotFound();
            else
            {

                var cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddHours(1);

                Response.Cookies.Append("session_id", user.Email, cookie);

            }

            return Ok(user);
        }

        // Register 
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegistrUser regUser)
        {
            if (regUser == null)
                return BadRequest();

            if (regUser.Password != regUser.ConfirmPassword)
                return BadRequest();

            var user = userContext.Users.SingleOrDefault(u => u.Email == regUser.Email);
            if (user != null)
                return BadRequest();

            userContext.Add(new Users
            {
                Email = regUser.Email,
                Password = regUser.Password,
                OrganizationId = 1,
                RolesId = 4,
            });
            userContext.SaveChanges();

            return Ok();
        }




       
    }
}
