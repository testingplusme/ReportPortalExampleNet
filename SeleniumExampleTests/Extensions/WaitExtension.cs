using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExampleTests.Extensions
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver, int seconds=20)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            Wait(driver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
