using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebDictionary.Pages.WorkPlace
{
    public class WorkPlaceModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        public WorkPlaceModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogInformation("GET Pages.PrivacyModel called.");
        }
    }
}
