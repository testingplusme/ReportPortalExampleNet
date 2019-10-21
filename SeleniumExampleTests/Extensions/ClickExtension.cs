using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExampleTests.Extensions
{
    public static class ClickExtension
    {
        public static void ClickWithWait(this IWebDriver driver, By by)
        {
            driver.WaitForClickable(by);
            var actions = new Actions(driver);
            actions.Click(driver.FindElement(by)).Perform();
            //driver.FindElement(by).Click();
        }
    }
}
