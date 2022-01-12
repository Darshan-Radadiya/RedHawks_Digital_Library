using ContosoCrafts.WebSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContosoCrafts.WebSite.Controllers.ProductsController;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Main class initialized.
    /// </summary>
    class ProductsControllerTest
    {
        #region TestSetup
        /// <summary>
        /// Test intialized.
        /// </summary>
        public static ProductsController ControllerBase;

        [SetUp]
        public void TestInitialize()
        {
            //contructer injection 
            ControllerBase = new ProductsController(TestHelper.ProductService)
            {

            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Get each valid product if its valid it should be in productlist.
        /// </summary>
        [Test]
        public void Get_EachValidProduct_Should_ProductList()
        {
            //Get and stores data of id which is match with the "Machine Learning_tom",
            var data = ControllerBase.Get().FirstOrDefault().Id.Equals("Machine Learning_tom");

            //Assert
            Assert.AreNotEqual(data, null);

        }
        #endregion OnGet

        /// <summary>
        /// Method to get and check valid string return string or not.
        /// </summary>
        [Test]
        public void Get_Valid_String_Should_Return_String()
        {
            {
                //Arrange
                //Get the data and convert in string.
                var data = ControllerBase.Get().FirstOrDefault().ToString();

                //Assert
                //check for string.
                Assert.AreEqual(typeof(string), data.GetType());
            }
        }

        /// <summary>
        /// Patched rating request and if its valid it should return OK (status code 200).
        /// </summary>
        [Test]
        public void PatchRatigRequest_Valid_Should_Return_Ok()
        {
            //Arrange
            //variable data is storing new data with JSON object of productID and Rating.
            var data = new RatingRequest
            {
                ProductId = "Machine Learning_tom",
                Rating = 5
            };
            //accepts rating on product with data available in variable data.
            var result = ControllerBase.Patch(data);

            //Act
            //okResult to make status code 200 (OK).
            var okResult = result as OkResult;

            //Assert
            //check status code of okResult with 200. 
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
