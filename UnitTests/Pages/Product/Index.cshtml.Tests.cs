using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// Unit test for the index functionality
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static IndexModel pageModel;
        /// <summary>
        /// Test initialized.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Get method gets the products and return true if products returned. 
        /// </summary>
        [Test]
        public void OnGet_True_Must_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}