using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>   
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService
        {
            // Data Service
            get;
        }

        /// <summary>
        /// REST Get request
        /// Loads the product
        /// </summary>
        public IEnumerable<ProductModel> Products
        {
            get;
            private set;
        }

        /// <summary>
        /// Onget we will get all data
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}