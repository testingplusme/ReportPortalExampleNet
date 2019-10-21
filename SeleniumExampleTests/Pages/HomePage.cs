using OpenQA.Selenium;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.Pages
{
    class HomePage
    {
        public By LeaveCommentLink = By.CssSelector(".comments-link");
        public By CookiePolicy = By.CssSelector(".accept");

        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage ClosePrivacyPolicy()
        {
            driver.ClickWithWait(CookiePolicy);
            return new HomePage(driver);
        }

        public ArticlePage EnterToCommentSection()
        {
            driver.ClickWithWait(LeaveCommentLink);
            return new ArticlePage(driver);
        }
    }
}
