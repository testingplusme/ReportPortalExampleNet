using NUnit.Framework;
using SeleniumExampleTests.BaseClass;
using SeleniumExampleTests.Pages;
using Shouldly;

namespace SeleniumExampleTests.Tests
{
    [TestFixture]
    public class ShopTests:BaseTest
    {
        [Test]
        public void Store_AddToCartAndRemove_CheckValidation()
        {
            driver.Navigate().GoToUrl("http://46.101.148.53");
            var shopMainPage = new ShopMainPage(driver);
            var emptyText = shopMainPage.AddToCart().
                GoToShoppingCart().
                RemoveFromCart().GetEmptyCartText();

            Assert.AreEqual(emptyText, "Your shopping cart is empty!");

        }



        [Test]
        public void Store_AddToCartAndRemove_CheckValidationWithShouldly()
        {
            driver.Navigate().GoToUrl("http://46.101.148.53");
            var shopMainPage = new ShopMainPage(driver);
            shopMainPage.AddToCart().
                GoToShoppingCart().
                RemoveFromCart()
                .GetEmptyCartText()
                .ShouldBe("Your shopping cart is empty!");
        }
    }
}
