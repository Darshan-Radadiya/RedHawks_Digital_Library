using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services.JsonFileProductService.AddComment
{
    /// <summary>
    /// Json Product services test
    /// </summary>
    public class JsonFileProductServiceAddCommentTests
    {
        #region TestSetup

        /// <summary>
        /// Initialize test setup
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        /// <summary>
        /// function to test the add comment or pass
        /// </summary>
        #region AddComment
        [Test]
        public void ProductService_AddComment_Data_Valid_Comment_Valid_No_Assert()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act this won't add into database cause no execution.
            TestHelper.ProductService.AddComment(data.Id, null);
        }
        #endregion AddComment
    }
}