//using System;
//using OpenQA.Selenium;

//namespace SeleniumExampleTests.Extensions.seleniumReporter
//{
//    public static class WebDriverListenerExtension

//    {

//        public static IWebDriver AddReportPortal(this IWebDriver webDriver, Func<Options, Options> optionsFunc = null)

//        {

//            var options = new Options();



//            options = optionsFunc == null ? options : optionsFunc.Invoke(new Options());



//            return new WebDriverListener(webDriver, options);

//        }

//    }
//}
