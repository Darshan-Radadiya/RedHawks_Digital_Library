using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Get and set methods that initializes properties for books 
    /// </summary>
    public class ProductModel
    {
        //product id
        public string Id { get; set; }
        public string Maker { get; set; }

        // Book cover
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Image URL (required field)
        [Required]
        public string Url { get; set; }

        // Book author
        public string Author { get; set; }

        // Book title (required field)
        [Required]
        public string Title { get; set; }

        //Book description (required field)
        [Required]
        public string Description { get; set; }

        // Book ratings
        public int[] Ratings { get; set; }

        // get set method for JSON attribute Comments
        public string[] Comments { get; set; }

        /// <summary>
        /// serilizing productModel.
        /// </summary>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}