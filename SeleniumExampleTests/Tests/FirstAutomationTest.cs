using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReportPortal.Extensions.Selenium;
using SeleniumExampleTests.Extensions;
using SeleniumExampleTests.Pages;

namespace SeleniumExampleTests.Tests
{
    [TestFixture]
    class FirstAutomationTest
    {
        [Test]
        public void EnterToDefineSite()
        {
            var driver = new ChromeDriver().AddReportPortal();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/");
            driver.Close();
        }

        [Test]
        public void EnterToHomePageTakeTitleAndCheckCorrectnessOfIt()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/");
            var title = driver.Title;
            Assert.AreEqual(title, "test");
            driver.Close();
        }

        [Test]
        public void EnterToHomePageTakeAllOfHeadingOneElements()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/");
            var headingsOne = driver.FindElements(By.CssSelector("h1"));
            Assert.AreEqual(headingsOne,"test");
            driver.Close();
        }


        [Test]
        public void EnterToPageWithDynamicLoadingElementAndCheckText()
        {
            
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_loading");
            driver.Wait().Until(x => x.FindElements(By.CssSelector(".example a")).Count==2);
            
            var exampleLink = driver.FindElements(By.CssSelector(".example a")).Where(x => x.Text == "Example 1: Element on page that is hidden").FirstOrDefault();
            exampleLink.Click();
            driver.WaitForClickable(By.CssSelector("#start button"));
            driver.FindElement(By.CssSelector("#start button")).Click();
            driver.WaitForClickable(By.CssSelector("#finish h4"));
            var textfromLoadedElement= driver.FindElement(By.CssSelector("#finish h4")).Text;
            Assert.AreEqual(textfromLoadedElement, "Hello World!");
            driver.Close();
        }

        [Test]
        public void EnterToDropDown()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            var selectElement = new SelectElement(driver.FindElement(By.CssSelector("#dropdown")));
            selectElement.SelectByText("Option 1");
            driver.Close();
        }

        [Test]
        public void LoginToAuthForm()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
            driver.WaitForClickable(By.CssSelector("#username"));
            driver.FindElement(By.CssSelector("#username")).SendKeys("tomsmith");
            driver.WaitForClickable(By.CssSelector("#password"));
            driver.FindElement(By.CssSelector("#password")).SendKeys("SuperSecretPassword!");
            driver.WaitForClickable(By.CssSelector("#login button"));
            driver.FindElement(By.CssSelector("#login button")).Click();
            driver.WaitForClickable(By.CssSelector("#flash-messages"));
            var flashMessageElement = driver.FindElement(By.CssSelector("#flash-messages .success"));
            Assert.IsTrue(flashMessageElement.Displayed);
            driver.WaitForClickable(By.CssSelector(".icon-signout"));
            driver.FindElement(By.CssSelector(".icon-signout")).Click();
            driver.Close();
        }

        [Test]
        public void Contact_FillAllOfFields_CheckInformationAfterSubmitForm()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/contact/");
            driver.WaitForClickable(By.CssSelector("#g2-name"));
            driver.ClickWithWait(By.CssSelector(".accept"));
            driver.FindElement(By.CssSelector("#g2-name")).SendKeys("example");
            driver.FindElement(By.CssSelector("#g2-email")).SendKeys("kontakt+qa@testingplus.me");
            driver.FindElement(By.CssSelector("#contact-form-comment-g2-comment")).SendKeys("text");
            driver.WaitForClickable(By.CssSelector(".pushbutton-wide"));
            var actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.CssSelector(".pushbutton-wide"))).Perform();
            driver.FindElement(By.CssSelector(".pushbutton-wide")).Click();
            driver.WaitForClickable(By.CssSelector("h3"));
            var textAfterSubmit = driver.FindElement(By.CssSelector("h3")).Text;
            Assert.AreEqual(textAfterSubmit, "Message Sent (go back)");
        }

        [Test]
        public void Contact_FillAllOfFields_CheckInformationAfterSubmitFormWithPageObject()
        {  
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/contact/");
            var contactFormPage = new ContactFormPage(driver);
            contactFormPage.ContactByContactForm("name", "kontakt+qaaa@testingplus.me", "comment");
            driver.WaitForClickable(contactFormPage.HeadingThree);
            var textAfterSubmit = driver.FindElement(contactFormPage.HeadingThree).Text;
            Assert.AreEqual(textAfterSubmit, "Message Sent (go back)");
            driver.Close(); 
        }

        [Test]
        public void Foo()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog/contact/");
            var contactFormPage = new ContactFormPage(driver);
            contactFormPage.ContactByContactForm("name", "kontakt+qaaa@testingplus.me", "comment");
            driver.WaitForClickable(contactFormPage.HeadingThree);
            var textAfterSubmit = driver.FindElement(contactFormPage.HeadingThree).Text;
            Assert.AreEqual(textAfterSubmit, "Message Sent (go back)");
            var actions = new Actions(driver);
            actions.Click(driver.FindElement(By.CssSelector("#contact-form-2 h3 a"))).Perform();
            driver.Close();
        }



        [Test]
        public void Comment_FillAllOfFields_ValidationAfterPostComment()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog");
            var homePage = new HomePage(driver);
            homePage.ClosePrivacyPolicy()
                .EnterToCommentSection()
                .LeaveComment("x", "x", "x", "x")
                .PostComment();
            ///---------------------------

            //homePage.ClosePrivacyPolicy();
            //homePage.EnterToCommentSection();
            //var articlePage = new ArticlePage(driver);
            //articlePage.LeaveComment("x", "x", "x", "x");
            //articlePage.PostComment();
           
        }

        [Test]
        public void Comment_FillAllOfFieldsWithClickOnCheckboxes_ValidationAfterPostComment()
        {
            var driver = new ChromeDriver().AddReportPortal();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testpagefor.home.blog");
            var homePage = new HomePage(driver);
            homePage.ClosePrivacyPolicy()
                .EnterToCommentSection()
                .LeaveComment("x", "x", "x", "x")
                .ClickSubscribe()
                .ClickSubscribeBlog()
                .PostComment();
           driver.Close();
        }

        [Test]
        public void Comment_FillAllOfFieldsWithClickOnCheckboxes_ValidationAfterPostCommentFiirefox()
        {

        }

    }
}
