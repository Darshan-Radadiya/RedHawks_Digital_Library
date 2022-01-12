    
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Unit test for the functionality
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;
        /// <summary>
        /// Test initialized.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //constructer for UpdateModel.
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// tets onGet it returning all books.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Refactoring: Improving the Design of Existing Code");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Refactoring: Improving the Design of Existing Code", pageModel.Product.Title);
        }

        /// <summary>
        /// when product id is null it will redirect to the read page.
        /// </summary>
        [Test]
        public void OnGet_Null_Product_Id_Return_To_Index_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet(null) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        #endregion OnGet

        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Url = "url",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}