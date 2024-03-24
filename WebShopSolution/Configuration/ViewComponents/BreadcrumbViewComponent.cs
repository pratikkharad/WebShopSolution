using Microsoft.AspNetCore.Mvc;
using WebShop.Core.ServiceContracts;

namespace WebShop.UI.Configuration.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IBreadcrumbService _breadcrumbService;

        public BreadcrumbViewComponent(IBreadcrumbService breadcrumbService)
        {
            _breadcrumbService = breadcrumbService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentPage = _breadcrumbService.GetCurrentPage();

            return View(currentPage);
        }
    }
}
