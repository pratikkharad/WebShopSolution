
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure.DataAccess;
using Shop.Infrastructure.DbContext;
using System.Data;
using System.Data.SqlClient;
using WebShop.Core.Domain.Entities;
using WebShop.Core.DTO;
using WebShop.Domain.Entities;
using WebShop.Domain.RepositoryContract;

namespace WebShop.Infrastructure.Repositorie
{
    public class PersonRepository : IPersonGetterRepoContract
    {
        private readonly ILogger<PersonRepository> _logger;
        private readonly DapperDBContext _dbContext;

        public PersonRepository(ILogger<PersonRepository> logger, DapperDBContext dbContext)
        {

            _logger = logger;
            _dbContext = dbContext;
        }

      
        public async Task<IEnumerable<PersonResponse>> GetPersonsList()
        {

            try
            {
                _logger.LogInformation("Action executed successfully.Class: {Class}, Method: {Method}",
           nameof(PersonRepository), nameof(GetPersonsList));

                using (var connection = await _dbContext.CreateConnectionAsync())
                {
                    var parameters = new DynamicParameters();                    
                  
                    IEnumerable<Person> results = await connection.QueryAsync<Person>(UserSqlConstants.GetUserList, parameters, commandType: CommandType.StoredProcedure);

                    // Check if there are any elements in the results
                    if (results.Any())
                    {
                        // Assuming you have the ConvertUserGuids method in a class called PersonExtensions
                        // results.ConvertUserGuids();

                        // Assuming ConvertToPerson method returns IEnumerable<PersonResponse>
                        IEnumerable<PersonResponse> dtoList = PersonResponseDTOConverter.ConvertToPerson(results);

                        return dtoList;
                    }
                }

            }
            catch (SqlException sqlException)
            {

                Console.WriteLine($"Error: {sqlException.Message}");

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
                using (var connection = await _dbContext.CreateConnectionAsync())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@SortBy", tableModel.SortBy);
                    parameters.Add("@Descending", tableModel.Descending);

                    IEnumerable<Person> results = await connection.QueryAsync<Person>(UserSqlConstants.GetSortedUsers, parameters, commandType: CommandType.StoredProcedure);

                    // Check if there are any elements in the results
                    if (results.Any())
                    {
                        
                        IEnumerable<PersonResponse> dtoList = PersonResponseDTOConverter.ConvertToPerson(results);

                        return dtoList;
                    }
                }

            }
            catch (SqlException sqlException)
            {

                Console.WriteLine($"Error: {sqlException.Message}");

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
                using (var connection = await _dbContext.CreateConnectionAsync())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", tableModel.PageNumber);
                    parameters.Add("@PageSize", tableModel.PageSize);

                    IEnumerable<Person> results = await connection.QueryAsync<Person>(UserSqlConstants.GetUserPageNumberAndSize, parameters, commandType: CommandType.StoredProcedure);

                    // Check if there are any elements in the results
                    if (results.Any())
                    {

                        IEnumerable<PersonResponse> dtoList = PersonResponseDTOConverter.ConvertToPerson(results);

                        return dtoList;
                    }
                }

            }
            catch (SqlException sqlException)
            {

                Console.WriteLine($"Error: {sqlException.Message}");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public async Task<IEnumerable<PersonResponse>> GetPersons(TableModel tableModel)
        {

            try
            {
                using (var connection = await _dbContext.CreateConnectionAsync())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@PageNumber", tableModel.PageNumber);
                    parameters.Add("@PageSize", tableModel.PageSize);

                    IEnumerable<Person> results = await connection.QueryAsync<Person>(UserSqlConstants.GetUserPageNumberAndSize, parameters, commandType: CommandType.StoredProcedure);

                    // Check if there are any elements in the results
                    if (results.Any())
                    {
                        // Assuming ConvertToPerson method returns IEnumerable<PersonResponse>
                        IEnumerable<PersonResponse> dtoList = PersonResponseDTOConverter.ConvertToPerson(results);

                        return dtoList;
                    }
                }

            }
            catch (SqlException sqlException)
            {

                Console.WriteLine($"Error: {sqlException.Message}");

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
                _logger.LogInformation("Action executed successfully.Class: {Class}, Method: {Method}",
           nameof(PersonRepository), nameof(GetPersonsList));

                using (var connection = await _dbContext.CreateConnectionAsync())
                {
                    var parameters = new DynamicParameters();

                    // ExecuteScalarAsync : user for the scalary function or numeric function executed the query 
                    int results = await connection.ExecuteScalarAsync<int>(UserSqlConstants.GetTotalUserCount, parameters, commandType: CommandType.StoredProcedure);

                    if (results > 0)
                    {
                        return results;
                    }
                }

            }
            catch (SqlException sqlException)
            {

                Console.WriteLine($"Error: {sqlException.Message}");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");

            }


            return 0;
        }
    }
}
