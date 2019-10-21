using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportPortal.Shared;

namespace SeleniumExampleTests.Tests
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        [Test]
        public void ExampleSimpleTest()
        {
            driver = new ChromeDriver();
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "class1 test4 log messzzxxzxzage");
            driver.Close();
        }
////
//        [TearDown]
//        public void TearDown()
//        {
//            var driverSessionId = (RemoteWebDriver) driver;
//            var pathToVideo = "http://157.230.117.38:8080" + "video" + driverSessionId.ToString();
//            TestContext.AddTestAttachment(pathToVideo, "video");
//        }


    }
}
