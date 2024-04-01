using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain.Entities;

namespace WebShop.Core.ServiceContracts
{
    public interface IBreadcrumbService
    {
        void SetCurrentPage(string title, string url);
        BreadcrumbItem GetCurrentPage();
    
    }
}
