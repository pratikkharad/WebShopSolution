using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
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

        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Login page is successful get request is recived");
            return View();
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index([FromBody] LoginDTO loginDTO)
        {            
            try
            {
                _logger.LogInformation("Login page is successful post request is recived");

                // check the model state is valid or not. 
                if (!ModelState.IsValid)
                {
                    // If model validation fails, return bad request with validation errors
                    return BadRequest(ModelState);
                }

                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {

                // Log the exception
                _logger.LogError(ex, "An error occurred while registering the user");

                // Return a generic error message to the client
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
    }
}
