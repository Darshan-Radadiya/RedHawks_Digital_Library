using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// class JasonFileProductService Initialized. 
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        ///  we can get the path to products.json 
        /// </summary>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Get method for web host environment
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment
        {
            get;
        }

        /// <summary>
        /// Get method that returns data to web host environment 
        /// </summary>
        private string JsonFileName // field
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
            }
        }

        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetAllData();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Adds a comment to the specified product ID
        /// </summary>
        /// <param name = "productId">ID of specific product</param>
        /// <param name = "comment">Comment to be added</param>
        public void AddComment(string productId, string comment)
        {
            var products = GetAllData();

            if (products.First(x => x.Id == productId).Comments == null)
            {
                //creates new list of comments
                products.First(x => x.Id == productId).Comments = new string[] { comment };
            }
            else
            {
                //adds comment to existing comments list
                var comments = products.First(x => x.Id == productId).Comments.ToList();
                comments.Add(comment);
                products.First(x => x.Id == productId).Comments = comments.ToArray();
            }

            SaveData(products);
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            productData.Title = data.Title;
            productData.Description = data.Description;
            productData.Url = data.Url;
            productData.Image = data.Image;      
            SaveData(products);
            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        { 
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title", 
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}