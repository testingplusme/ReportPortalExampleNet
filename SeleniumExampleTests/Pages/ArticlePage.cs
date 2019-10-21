using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.Pages
{
    class ArticlePage
    {
        IWebDriver driver;
        public By CommentTextArea = By.CssSelector("#comment");
        public By Email = By.CssSelector("#email");
        public By Name = By.CssSelector("#author");
        public By Website = By.CssSelector("#url");
        public By Submit = By.CssSelector("#comment-submit");
        public By SubscribeCheckBox = By.CssSelector("#subscribe");
        public By SubscribeBlogCheckBox = By.CssSelector("#subscribe_blog");

        public ArticlePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ArticlePage LeaveComment(string name, string email, string website, string comment)
        {
            driver.ClickWithWait(CommentTextArea);
            driver.FindElement(CommentTextArea).SendKeys(comment);
            driver.WaitForClickable(Name);
            driver.FindElement(Name).SendKeys(name);
            driver.WaitForClickable(Email);
            driver.FindElement(Email).SendKeys(email);
            driver.WaitForClickable(Website);
            driver.FindElement(Website).SendKeys(website);
            return new ArticlePage(driver);
        }


        public ArticlePage ClickSubscribe()
        {
            driver.ClickWithWait(SubscribeCheckBox);
            return new ArticlePage(driver);
        }

        public ArticlePage ClickSubscribeBlog()
        {
            var actions = new Actions(driver);

            if (TestSettings.Browser==Browser.Firefox)
                //         driver.ExecuteScript("scroll(0,450);");

            actions.MoveToElement(driver.FindElement(SubscribeBlogCheckBox)).Click().Perform();
            driver.ClickWithWait(SubscribeBlogCheckBox);
            return new ArticlePage(driver);
        }

       

        public void PostComment()
        {
            driver.ClickWithWait(Submit);
        }

    }
}
