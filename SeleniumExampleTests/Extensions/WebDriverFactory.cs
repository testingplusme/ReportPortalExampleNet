using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumExampleTests.Extensions
{
    public enum Browser
    {
        Firefox,
        Chrome,
        ChromeRemote,
    }
    public class WebDriverFactory
    {
        public IWebDriver GetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Firefox:
                    return new FirefoxDriver();
                case Browser.Chrome:
                    return new ChromeDriver();
                case Browser.ChromeRemote:
                    var capabilities = new DesiredCapabilities("chrome", "76.0", new Platform(PlatformType.Any));
                    capabilities.SetCapability("enableVNC", true);
                    capabilities.SetCapability("enableVideo", true);
                    return new RemoteWebDriver(new Uri("http://157.230.117.38:4444/wd/hub"), capabilities);
            }
            return null;
        }
    }

}
