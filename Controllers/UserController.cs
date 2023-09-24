using Microsoft.AspNetCore.Mvc;

namespace code_wizards_api.Models
{
    [Route("NotesAPI/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return Ok();
        }
    }
}