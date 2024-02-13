namespace HousingDB.Controllers
{
    using DBModels;
    using HousingModel;
    using Microsoft.AspNetCore.Mvc;

    namespace HousingDB.Controllers
    {
        [ApiController]
        [Route("api/[controller]/[action]")]
        public class AppUserController : ControllerBase
        {
            HousingDBContext context;
            public AppUserController(HousingDBContext context)
            {
                this.context = context;
            }
            [HttpGet(Name = "Test")]
            public ActionResult Test()
            {
                return Ok("Hello World");
            }
            [HttpPost(Name ="Login")]
            public ActionResult<AppUser?> Login([FromBody] AppLogin data)
            {
                AppUser? user = context.AppUsers.Where(u => u.Email.ToLower()==data.Email.ToLower() && u.Password==data.Password).FirstOrDefault();
                if(user == null)
                {
                    return NotFound();
                }
                return user;
            }
            [HttpPost(Name = "Login2")]
            public ActionResult<int> Login2([FromBody] AppLogin data)
            {
                AppUser? user = context.AppUsers.Where(u => u.Email.ToLower() == data.Email.ToLower() && u.Password == data.Password).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }
                return user.Id;
            }
            [HttpPost(Name = "Register")]
            public ActionResult Register([FromBody]AppUser user)
            {
                //First check if user exists - if so, issue an error
                AppUser? appuser = context.AppUsers.Where(u => u.Email.ToLower() == user.Email.ToLower() && 
                u.Password == user.Password).FirstOrDefault();
                //Not exists - OK, add him
                if (appuser == null)
                {
                    context.AppUsers.Add(user);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return Problem("User already exists");
                }
            }
            [HttpPost(Name = "ChangePassword")]
            public ActionResult ChangePassword([FromForm] string email, [FromForm] string oldPassword, [FromForm] string newPassword)
            {
                //check if user exists
                AppUser? appuser = context.AppUsers.Where(u => u.Email.ToLower() == email.ToLower() &&
                u.Password == oldPassword).FirstOrDefault();
                if (appuser != null)
                {
                    appuser.Password = newPassword;
                    context.AppUsers.Update(appuser);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
