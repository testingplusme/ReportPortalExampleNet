using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportPortal.Client.Models;
using ReportPortal.Client.Requests;
using ReportPortal.Shared;
using LogLevel = ReportPortal.Client.Models.LogLevel;

namespace SeleniumExampleTests.Extensions.seleniumReporter
{
    public static class WebDriverListener 

    {



//
//        public WebDriverListener(IWebDriver parentDriver, Options options) : base(parentDriver)
//
//        {
//
//            _options = options;
//
//
//
//            this.Navigating += WebDriverListener_Navigating;
//
//            this.Navigated += WebDriverListener_Navigated;
//
//            this.FindingElement += WebDriverListener_FindingElement;
//
//            this.ElementClicking += WebDriverListener_ElementClicking;
//
//            this.ElementClicked += WebDriverListener_ElementClicked;
//
//            this.ElementValueChanged += WebDriverListener_ElementValueChanged;
//
//        }



        public static void WebDriverListener_Navigating(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)

        {

            LogMessage($"Navigating to {e.Url}");

        }


        public static void WebDriverListener_ElementClicked(object sender, OpenQA.Selenium.Support.Events.WebElementEventArgs e)

        {

            LogScreenshot(e.Driver as ChromeDriver,$"{e.Element} clicked");

        }



        public static void WebDriverListener_ElementClicking(object sender, OpenQA.Selenium.Support.Events.WebElementEventArgs e)

        {

            LogMessage($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");

        }


        public static  void WebDriverListener_FindingElement(object sender, OpenQA.Selenium.Support.Events.FindElementEventArgs e)

        {

            LogMessage($"Finding element `{e.FindMethod}`");

        }


        public static void WebDriverListener_ElementValueChanged(object sender, OpenQA.Selenium.Support.Events.WebElementValueEventArgs e)

        {

            LogScreenshot((ChromeDriver) e.Driver, $"Value of the {e.Element} changed to `{e.Value}`");

        }



        private static void WebDriverListener_Navigated(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)

        {

            LogScreenshot(e.Driver as ChromeDriver,$"Navigated to [{e.Driver.Title}]({e.Url})");

        }


        public static void LogMessage(string text)

        {

            Log.Message(new AddLogItemRequest

            {

                Level = LogLevel.Info,

                Time = DateTime.UtcNow,

                Text = $"{text}"

            });

        }



        private static void LogScreenshot(this ChromeDriver driver, string text)

        { 
            var screenshot = driver.GetScreenshot().AsByteArray;

            Log.Message(new AddLogItemRequest

            {

                Level =LogLevel.Info,

                Time = DateTime.UtcNow,

                Text = $"{text}",

                Attach = new Attach

                {

                    Name = "Screenshot",

                    MimeType = "image/png",

                    Data = screenshot

                }

            });

        }

    }
}
