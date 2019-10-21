using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.Pages
{
    class ContactFormPage
    {
        private IWebDriver driver;
        public By Name = By.CssSelector("#g2-name");
        public By Comment = By.CssSelector("#contact-form-comment-g2-comment");
        public By Submit = By.CssSelector(".pushbutton-wide");
        public By Email = By.CssSelector("#g2-email");
        public By HeadingThree = By.CssSelector("h3");
        public By CookiePolicy => By.CssSelector(".accept");



        public ContactFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ContactByContactForm(string name, string email, string comment)
        {
            driver.WaitForClickable(Name);
            driver.ClickWithWait(CookiePolicy);
            driver.FindElement(Name).SendKeys(name);
            driver.FindElement(Email).SendKeys(email);
            driver.FindElement(Comment).SendKeys(comment);
            driver.WaitForClickable(Submit);
            var actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(Submit)).Perform();
            driver.ClickWithWait(Submit);
            //
        }
    }
}
