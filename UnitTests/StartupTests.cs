using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// Main starup test class.
    /// </summary>
    public class StartupTests
    {
        #region TestSetup
        /// <summary>
        ///  Initializing test 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// Startup of test
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        /// <summary>
        /// Testing for Startup configuration services and valid should pass.
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            //to create web host.
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            //Assert
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region Configure
        /// <summary>
        /// test for startup configuration valid default should pass.
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            // to create webHost
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            //Assert
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}