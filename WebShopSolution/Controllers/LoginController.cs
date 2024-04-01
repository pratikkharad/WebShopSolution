using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebShop.Core.DTO;
using WebShop.Core.ServiceContracts;

namespace WebShop.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogger<LoginController> _logger;
        private readonly ILoginContracts _loginContracts;

        public LoginController(ILogger<LoginController> logger, ILoginContracts loginContracts)
        {
            _logger = logger;
            _loginContracts = loginContracts;
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
        public async Task<IActionResult> IndexAsync([FromBody] LoginDTO loginDTO)
        {            
            try
            {
                _logger.LogInformation("Login page is successful post request is recived");
                _logger.LogInformation("Action executed successfully. Controller: {Controller}, Method: {Method}",
             nameof(LoginController), nameof(IndexAsync));

                // check the model state is valid or not. 
                if (!ModelState.IsValid)
                {
                    // If model validation fails, return bad request with validation errors
                    //return BadRequest(ModelState);

                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    return View(loginDTO);
                }

                bool loginResult = await _loginContracts.LoginAsync(loginDTO);

                if (!loginResult)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Make sure enter valid password and user name");
                }

                // Authentication successful
                return Json(new { success = true, message = "Login successful." });

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
