using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Model;
using System.Net;

namespace MyProject.Controllers
{
    public class OrganizationController : Controller
    {


        private UserContext userContext;
        private Users currentUser;

        public OrganizationController(UserContext appContext)
        {

            userContext = appContext;
            var curUser = (from user in userContext.Users
                           where user.Email == userContext.Users.FindAsync(Request.Cookies["session_id"]).ToString()
                           select user).ToList();
            currentUser = curUser.First();
        }

        [HttpGet("GetDocument")]
        public IActionResult GetUsers()
        {
            if(currentUser.Roles.Can_Read_Documents==false)
                return Ok("You don't have permission");

            return Ok();
        }

      
        [HttpPost("CreateDocument")]
        public IActionResult CreateDocument()
        {
            if (currentUser.Roles.Can_Create_Documents == false)
                return Ok("You don't have permission");

            return Ok();
        }

        [HttpPut("UpdateDocument")]
        public IActionResult UpdateDocument([FromBody] RegistrUser regUser)
        {
            if (currentUser.Roles.Can_Update_Documents == false)
                return Ok("You don't have permission");

            return Ok();
        }



    }
}
