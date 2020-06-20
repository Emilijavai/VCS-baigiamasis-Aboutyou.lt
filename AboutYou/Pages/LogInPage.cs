using AboutYou.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AboutYou
{
    public class LogInPage :PageBase
    {
        private IWebElement _paskyrosMygtukas => _driver.FindElement(By.ClassName("_userIcon_e381b"));
        private IWebElement _emailLaukas => _driver.FindElement(By.Name("email"));
        private IWebElement _passwordLaukas => _driver.FindElement(By.Name("password"));
        private IWebElement _logInMygtukas => _driver.FindElement(By.XPath("//*[@id='theme-aboutyou']/main/section/div/div/div[2]/form/button"));
        private By _countrySelectLocator => By.XPath("//*[@id='app']/div/div[2]/span/div[2]/strong");


        public LogInPage(IWebDriver inputDriver) : base(inputDriver) { }

        public LogInPage AtidarytiPagrindiPuslapi()
        {
            _driver.Url = "https://www.aboutyou.lt/";

            return this;

        }

        public LogInPage PridetiCookie()
        {
            Cookie myCookie = new Cookie
                ("OptanonAlertBoxClosed",
               "DateTime.Now.ToString(2020-06-08T15:48:11.464Z)",
               ".aboutyou.lt",
               "/", DateTime.Now.AddDays(1));


            _driver.Manage().Cookies.AddCookie(myCookie);

            _driver.Navigate().Refresh();

            return this;
        }
        public LogInPage SelectCountry()
        {
            var elements = _driver.FindElements(_countrySelectLocator);

            if (elements.Count > 0)
            {
                elements.First().Click(); 
            }

            return this;
        }


        public LogInPage EitiILogInPuslapi()
        {
            _paskyrosMygtukas.Click();

            return this;
        }

        public FrontPagePage AtliktiPrisijungimaPriePaskyros(string email, string password)
        {
            Thread.Sleep(3000);

            _driver.SwitchTo().Frame(0);

            _emailLaukas.Clear();
            _emailLaukas.SendKeys(email);
            _passwordLaukas.Clear();
            _passwordLaukas.SendKeys(password);
            _logInMygtukas.Submit();


            return new FrontPagePage(_driver);
        }




    }
}
