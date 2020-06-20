using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Pages
{
   public class PageBase
    {
        protected static IWebDriver _driver;

        public PageBase(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void CloseBrowser()
        {
            _driver.Quit();
        }

        public WebDriverWait GetWait(int seconds = 7)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }
    }
}
