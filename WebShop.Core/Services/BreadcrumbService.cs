using WebShop.Core.ServiceContracts;
using WebShop.Core.Domain.Entities;

namespace WebShop.Core.Services
{
    public class BreadcrumbService : IBreadcrumbService
    {
        private BreadcrumbItem _currentPage;
  

        public void SetCurrentPage(string title, string url)
        {
            _currentPage = new BreadcrumbItem { Title = title, Url = url };
        }

        public BreadcrumbItem GetCurrentPage()
        {
            return _currentPage;
        }

     
    }
}
