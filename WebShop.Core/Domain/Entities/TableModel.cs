using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Domain.Entities
{
    public class TableModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? SortBy { get; set; }
        public bool? Descending { get; set; }
        public int? TotalRecords { get; set; }
        public string? searchBy { get; set; }
        public string? searchString { get; set; }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Records { get; set; }
        public int TotalRecords { get; set; }
    }

}
