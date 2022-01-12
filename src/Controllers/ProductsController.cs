using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Products controller base class for  MVC controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        /// <summary>
        /// Get method initializing book components
        /// </summary>
        public JsonFileProductService ProductService
        {
            get; 
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData(); // Returns book data
        }

        /// <summary>
        /// Accepts rating on products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// Get and set methods that accepts rating for books
        /// </summary>
        public class RatingRequest
        {
            /// get set method for the product ID
            public string ProductId { get; set; }

            /// get set method for the comment
            public int Rating { get; set; }
        }
    }
}