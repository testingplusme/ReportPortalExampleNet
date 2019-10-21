using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            TestSettings.Browser = Browser.Chrome;
            driver = new WebDriverFactory().GetDriver(TestSettings.Browser);
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TearDown()
        {
            
            driver.Close();
        }
    }
}
