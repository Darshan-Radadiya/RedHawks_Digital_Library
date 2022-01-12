using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    /// <summary>
    /// Main class initialized.
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        /// <summary>
        /// Test Initialized
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddRating
        /// <summary>
        /// Testing to check if a invalid product null will return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange
            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);
            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing if a null rating return false.
        /// </summary>
        [Test]
        public void AddRating_Data_Null_Should_Return_False()
        {
            // Arrange
            // Act
            var result = TestHelper.ProductService.AddRating("12345", 4);
            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for the rating less than 0.
        /// </summary>
        [Test]
        public void Rating_lessThan_Zero_Return_False()
        {
            var result = TestHelper.ProductService.AddRating("Cracking the Coding Interview", -1);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for the rating greater than five.
        /// </summary>
        [Test]
        public void Rating_GreaterThan_Five_Return_False()
        {
            var result = TestHelper.ProductService.AddRating("Cracking the Coding Interview", 6);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for the rating with null value.
        /// </summary>
        [Test]
        public void AddRating_Product_With_NullRating_CreatesObject()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().Where(x => x.Id == "Cracking the Coding Interview").FirstOrDefault();

            // Act
            var result = TestHelper.ProductService.AddRating("Cracking the Coding Interview", 4);
            var dataNewList = TestHelper.ProductService.GetAllData().Where(x => x.Id == "Cracking the Coding Interview").FirstOrDefault();

            //Assert
            Assert.AreEqual(1, dataNewList.Ratings.Length);
        }
        #endregion AddRating
    }
}