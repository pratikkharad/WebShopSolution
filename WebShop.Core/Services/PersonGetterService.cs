using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebShop.Core.Domain.Entities;
using WebShop.Core.DTO;
using WebShop.Core.ServiceContracts;
using WebShop.Domain.RepositoryContract;


namespace WebShop.Core.Services
{
    public class PersonGetterService : IPersonGetterContracts
    {
        private readonly ILogger<PersonGetterService> _logger;
        private readonly IPersonGetterRepoContract _personGetterRepoContract;

        public PersonGetterService(ILogger<PersonGetterService> logger, IPersonGetterRepoContract personGetterRepoContract)
        {
            _logger = logger;
            _personGetterRepoContract = personGetterRepoContract;
        }

        public async Task<IEnumerable<PersonResponse>> GetFilteredPersons(string searchBy, string? searchString)
        {
            IEnumerable<PersonResponse> allPersonResponse = await GetPersonsList();
            IEnumerable<PersonResponse> matchingPersons =  allPersonResponse;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return allPersonResponse;
            }

            switch (searchBy)
            {
                case nameof(PersonResponse.FirstName):
                    matchingPersons = allPersonResponse.Where(temp => (!string.IsNullOrEmpty(temp.FirstName) ? temp.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Email):
                    matchingPersons = allPersonResponse.Where(temp => (!string.IsNullOrEmpty(temp.Email)? temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersonResponse.Where(temp => (temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd MMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.PhoneNumber):
                    matchingPersons = allPersonResponse.Where(temp => (!string.IsNullOrEmpty(temp.PhoneNumber) ? temp.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                default:
                    matchingPersons = allPersonResponse;
                    break;
            }

            return matchingPersons;
        }

        public async Task<IEnumerable<PersonResponse>> GetPersons(TableModel tableModel)
        {
            try
            {
                if (tableModel.PageSize == 0)
                {
                    return null;
                }

                return await _personGetterRepoContract.GetPersons(tableModel);


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<IEnumerable<PersonResponse>> GetPersonsList()
        {          
            try
            {
                _logger.LogInformation("Action executed successfully.Class: {Class}, Method: {Method}",
            nameof(PersonGetterService), nameof(GetPersonsList));

                IEnumerable<PersonResponse> response = await _personGetterRepoContract.GetPersonsList();

                return response;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");

            }

            return null;
        }

        public async Task<IEnumerable<PersonResponse>> GetSortPersons(TableModel tableModel)
        {
            try
            {
                if (string.IsNullOrEmpty(tableModel.SortBy))
                {
                    return null;
                }

                return await _personGetterRepoContract.GetSortPersons(tableModel);


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<IEnumerable<PersonResponse>> GetPagedData(TableModel tableModel)
        {
            try
            {
                if (tableModel.PageNumber == 0 || tableModel.PageSize == 0 )
                {
                    return null;
                }

                return await _personGetterRepoContract.GetPagedData(tableModel);


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<int> GetTotalUserCount()
        {
            try
            {
                return await _personGetterRepoContract.GetTotalUserCount();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return 0;
        }

        public async Task<PersonResponse> GetPersonsByUserName(LoginDTO loginRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(loginRequest.UserName))
                {
                    return null;
                }

                PersonResponse personResponse = await _personGetterRepoContract.GetPersonsByUserName(loginRequest);

                if (personResponse is null)
                {
                    return null;
                }

                return personResponse;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while registering the user");                               
                
            }

            return null;

        }
    }
}
