using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    /// <summary>
    /// Error handling class
    /// </summary>
    public class ErrorModel : PageModel
    {
        // String RequestID is defined and get and set method provided.
        public string RequestId { get; set; }

        //boolean showRequestID checks for RequestID its null or empty and not a string.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //Interface for logging.
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// default generic constructer created for this page.
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get method to get the requestID from user activity.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}