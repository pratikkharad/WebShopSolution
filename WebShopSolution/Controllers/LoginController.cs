using Microsoft.AspNetCore.Mvc;
using WebShop.Core.DTO;

namespace WebShop.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet]        
        public IActionResult Index()
        {
            _logger.LogInformation("Login page is successful get request is recived");
            return View();
        }

        [HttpPost]    
        public IActionResult Index(LoginDTO loginDTO)
        {
            _logger.LogInformation("Login page is successful post request is recived");

            // check the model state is valid or not. 
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }





            return View();
        }
    }
}
