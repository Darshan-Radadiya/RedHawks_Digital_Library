using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Abstract class define for page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// default constructer is created.
        /// </summary>
        /// <param name="logger"></param>
        /// <return></return>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Request.
        /// </summary>
        public void OnGet() {}
    }
}