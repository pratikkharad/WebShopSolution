using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Globalization;
using WebShop.Core.Domain.Entities;
using WebShop.Core.DTO;
using WebShop.Core.ServiceContracts;
using WebShopSolution.Models;

namespace WebShopSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBreadcrumbService _breadcrumbService;
        private readonly IPersonGetterContracts _personGetterContracts;

        public HomeController(ILogger<HomeController> logger, IBreadcrumbService breadcrumbService, IPersonGetterContracts personGetterContracts)
        {
            _logger = logger;
            _breadcrumbService = breadcrumbService;
            _personGetterContracts = personGetterContracts;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] TableModel tableFunctionality)
        {
            _breadcrumbService.SetCurrentPage("Home", "Index");
            _logger.LogInformation("Home page is successful open");
            IEnumerable<PersonResponse> person = null;
                      
            try
            {
                // Set default values if not provided
                int defaultPageSize = 10; // Default page size
                int defaultPageNumber = 1; // Default page number

                tableFunctionality.PageNumber ??= defaultPageNumber;
                tableFunctionality.PageSize ??= defaultPageSize;

                // Validate page number and page size to prevent negative or zero values
                tableFunctionality.PageNumber = tableFunctionality.PageNumber <= 0 ? defaultPageNumber : tableFunctionality.PageNumber;
                tableFunctionality.PageSize = tableFunctionality.PageSize <= 0 ? defaultPageSize : tableFunctionality.PageSize;
                // This is drop down of the table also right side value show as display value 
                ViewBag.SearchFields = new Dictionary<string, string>()
                {
                    { nameof(PersonResponse.FirstName), "Person Name" },
                     { nameof(PersonResponse.Email), "Email" },
                    { nameof(PersonResponse.DateOfBirth), "Date Of Birth" },
                    { nameof(PersonResponse.PhoneNumber), "Phone Number" }
                   
                };

     
                if (!string.IsNullOrEmpty(tableFunctionality.searchString) && !string.IsNullOrEmpty(tableFunctionality.searchBy))
                {
                    person = await _personGetterContracts.GetFilteredPersons(tableFunctionality.searchBy, tableFunctionality.searchString);

                    ViewBag.TotalPages = (person.Count() + tableFunctionality.PageSize - 1) / tableFunctionality.PageSize;
                }
                else if(tableFunctionality.PageNumber > 0)
                {
                    person = await _personGetterContracts.GetPersons(tableFunctionality);

                    // Send 1 value for store procedure if need the count of user then send the value = 1 
                   

                }
                else if (!string.IsNullOrEmpty(tableFunctionality.SortBy))
                {

                    if (!tableFunctionality.Descending.HasValue)
                    {
                        tableFunctionality.Descending = false; // Default sorting order
                    }                                         

                    person = await _personGetterContracts.GetSortPersons(tableFunctionality);                  

                }
                else
                {
                    person = await _personGetterContracts.GetPagedData(tableFunctionality);
                }

               
                var totalUserCount = await _personGetterContracts.GetTotalUserCount(); 
                

                if (person == null)
                {
                    _logger.LogError("Failed to retrieve persons list: Result is null");
                }

                ViewBag.SortBy = tableFunctionality.SortBy;
                ViewBag.Descending = tableFunctionality.Descending;
                ViewBag.CurrentPage = tableFunctionality.PageNumber;
                ViewBag.PageSize = tableFunctionality.PageSize;
                ViewBag.TotalPages = (totalUserCount + tableFunctionality.PageSize - 1) / tableFunctionality.PageSize;



            }
            catch (Exception ex)
            {

                _logger.LogError("Home page is failed");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {

        }

        

      
    }
}
