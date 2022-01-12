using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Create test for class for the product/create
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;
        /// <summary>
        /// Test initialized.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //constructer for CreateModel.
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Method to test if on Get returning all book list.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            //variable to store old count of total books.
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            //checking oldCount+1 and current count of books.
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}