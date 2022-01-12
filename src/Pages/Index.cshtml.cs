using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for the Home Page
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// REST Get request
        /// Loads the product
        ///</summary>
        public IEnumerable<ProductModel> Products 
        {
            get; 
            private set;
        }

        /// <summary>
        ///onGet we will get all data
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}