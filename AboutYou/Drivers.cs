using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou
{
    public class Drivers
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFireFoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");

            return new ChromeDriver(options);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webDriver = null;

            switch (browserName)
            {
                case Browsers.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browsers.Chrome:
                    webDriver = GetChromeWithOptions();
                    break;

            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webDriver;
        }


       
    }
}
