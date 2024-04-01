using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain.Entities;
using WebShop.Core.DTO;

namespace WebShop.Core.ServiceContracts
{
    public interface IPersonGetterContracts
    {
        Task<IEnumerable<PersonResponse>> GetPersonsList();

        /// <summary>
        /// Returns all person objects that matches with the given search field and search string 
        /// </summary>
        /// <param name="searchBy"> search field to search </param>
        /// <param name="searchString"> search string to searchString</param>
        /// <returns></returns>
        Task<IEnumerable<PersonResponse>> GetFilteredPersons(string searchBy, string? searchString);

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
