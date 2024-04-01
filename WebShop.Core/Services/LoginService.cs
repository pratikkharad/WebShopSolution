using Microsoft.Extensions.Logging;
using Shop.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Helper;
using WebShop.Core.ServiceContracts;
using WebShop.Domain.RepositoryContract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebShop.Core.Services
{
    public class LoginService : ILoginContracts
    {

        private readonly ILogger<LoginService> _logger;
        
        private readonly IPersonGetterRepoContract _personGetterRepo;

        public LoginService(ILogger<LoginService> logger, IPersonGetterRepoContract personGetterRepo)
        {
            _logger = logger;
            _personGetterRepo = personGetterRepo;
        }

        public async Task<bool> LoginAsync(LoginDTO loginRequest)
        {
            if (loginRequest is null)
            {
                return false;
            }

            // Get the user hash password 
            PersonResponse person = await _personGetterRepo.GetPersonsByUserName(loginRequest);

            if (person == null) { return false;  }

            ClaimsPrincipalHelper.ClaimsPrincipal(loginRequest.UserName);


            // check the user passwordhash stored value with the input value 
            bool isPasswordValid = PasswordHelper.ValidationPassword(loginRequest.Password, person.PasswordHash);

            if (isPasswordValid) { return true; }

            return false;
        }
    }
}
