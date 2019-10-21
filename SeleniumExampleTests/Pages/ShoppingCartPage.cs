using OpenQA.Selenium;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.Pages
{
    public class ShoppingCartPage
    {
        IWebDriver driver;
        public By RemoveButton = By.CssSelector(".fa-times-circle");
        public By EmptyCartText = By.CssSelector("#content p");
        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ShoppingCartPage RemoveFromCart()
        {
            driver.ClickWithWait(RemoveButton);
            return new ShoppingCartPage(driver);
        }

        public string GetEmptyCartText()
        {

            driver.Wait().Until(x => x.FindElement(EmptyCartText).Text == "Your shopping cart is empty!");
            //driver.WaitForClickable(EmptyCartText);
            return driver.FindElement(EmptyCartText).Text;
        }



    }
}
