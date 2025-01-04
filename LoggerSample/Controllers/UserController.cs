using Microsoft.AspNetCore.Mvc;

namespace LoggerSample.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("User")]
        public IActionResult User()
        {
            string resutl = "it is User Controller";

            return Ok(resutl);
        }
    }
}
