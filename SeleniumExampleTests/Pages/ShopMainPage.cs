using OpenQA.Selenium;
using SeleniumExampleTests.Extensions;

namespace SeleniumExampleTests.Pages
{
    public class ShopMainPage
    {
        private IWebDriver driver;
        public By AddToCartButton = By.CssSelector(".product-layout .fa-shopping-cart");
        public By GoToCheckoutButton = By.CssSelector("#top-links .fa-shopping-cart");
        public ShopMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ShopMainPage AddToCart()
        {
            driver.ClickWithWait(AddToCartButton);
            return new ShopMainPage(driver);
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            driver.ClickWithWait(GoToCheckoutButton);
            return new ShoppingCartPage(driver);
        }

    }
}
