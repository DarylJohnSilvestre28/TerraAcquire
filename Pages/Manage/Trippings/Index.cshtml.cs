using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TerraAcquire.Web.Pages.Manage.Trippings
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly ITrippingService _trippingService;

        [BindProperty]
        public ViewModel Data { get; set; }
        public Index(ILogger<Index> logger, ITrippingService trippingService)
        {
            _logger = logger;
            _trippingService = trippingService;

            Data = Data ?? new ViewModel();
        }

        public void OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", string? keyword = "")
        {
            Data.Entity = _trippingService.Search(pageIndex, pageSize, sortBy, keyword);
        }

        public class ViewModel
        {

            public string? Entity { get; set; }
            public string? Items { get; set; }
        }
    }

    public interface ITrippingService
    {
        string? Search(int? pageIndex, int? pageSize, string? sortBy, string? keyword);
    }
}