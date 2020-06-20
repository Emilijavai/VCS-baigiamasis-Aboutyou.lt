using AboutYou.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Tests
{
   public  class TestBase
    {
        public static IWebDriver _driver;
        public static DzinsaiPage _dzinsaiPage;
        public static LogInPage _logInPage;
        public static FrontPagePage _frontPagePage;


        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _driver = Drivers.GetChromeWithOptions();
         
            _dzinsaiPage = new DzinsaiPage(_driver);
            _logInPage = new LogInPage(_driver);
            _frontPagePage = new FrontPagePage(_driver);

        }


        [TearDown]
        public static void SingleTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.MakePhoto(_driver);
            }
        }


        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
