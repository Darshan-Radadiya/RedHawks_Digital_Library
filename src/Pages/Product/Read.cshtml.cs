using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model for Read Page
    /// </summary>
    public class ReadModel : PageModel
    {
        // Comment variable required and max length
        [BindProperty]
        public string Comment { get; set; }

        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        /// <return></return>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        /// <return></return>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if(Product==null)
            {
                return RedirectToPage("./Index");     
            }
            return Page();
        }

        /// <summary>
        /// REST Post request to add a comment
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //var comment = Request.Form["comment"];

            if (Comment == null)
            {
                return RedirectToPage("./Read");
            }

            if (Comment.Length <= 0)
            {
                return RedirectToPage("./Read");
            }

            if (Comment.Length > 250)
            {
                return RedirectToPage("./Read");
            }

            ProductService.AddComment(Product.Id, Comment);

            return RedirectToPage("./Read");
        }
    }
}