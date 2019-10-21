using NUnit.Framework;
using SeleniumExampleTests.BaseClass;
using SeleniumExampleTests.Pages;

namespace SeleniumExampleTests.Tests
{
    [TestFixture]
    public class AutomationTestsMoreTests : BaseTest
    {
        [Test]
        public void Comment_FillAllOfFieldsWithClickOnCheckboxes_ValidationAfterPostComment()
        {
            driver.Navigate().GoToUrl("https://testpagefor.home.blog");
            var homePage = new HomePage(driver);
            homePage.ClosePrivacyPolicy()
                .EnterToCommentSection()
                .LeaveComment("x", "x", "x", "x")
                .ClickSubscribe()
                .ClickSubscribeBlog()
                .PostComment();
        }

       
    }
}
