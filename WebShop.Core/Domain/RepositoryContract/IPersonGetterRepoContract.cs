using WebShop.Core.Domain.Entities;
using WebShop.Core.DTO;

namespace WebShop.Domain.RepositoryContract
{
    public interface IPersonGetterRepoContract
    {
        Task<IEnumerable<PersonResponse>> GetPersonsList();

        /// <summary>
        /// This filter the data based on the page size and sorted column 
        /// </summary>
        /// <param name="sortColumn"> Any column can user sort</param>
        /// <param name="sortOrder"> Any column sort</param>
        /// <param name="page"> </param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        /// <summary>
        /// This filter the data based on the page size and sorted column 
        /// </summary>
        /// <param name="page"> </param>
        /// <param name="pageSize"></param>
        /// <returns></returns>       
        Task<IEnumerable<PersonResponse>> GetPersons(TableModel tableModel);

        /// <summary>
        /// This is used by sorting the column
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        Task<IEnumerable<PersonResponse>> GetSortPersons(TableModel tableModel);

        /// <summary>
        /// This is return the page size and page number 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<PersonResponse>> GetPagedData(TableModel tableModel);


        /// <summary>
        /// Return the total user count of rwo 
        /// This method user for the pagination
        /// </summary>
        /// <returns>The count of row</returns>
        Task<int> GetTotalUserCount();

        /// <summary>
        /// This method use for the get user details based on the username return only matched records.
        /// </summary>
        /// <param name="userName">This parameter base base get the records</param>
        /// <returns>This method return the only one matched records return</returns>
        Task<PersonResponse> GetPersonsByUserName(LoginDTO loginRequest);




    }
}
