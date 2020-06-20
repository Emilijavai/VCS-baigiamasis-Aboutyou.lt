using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Pages
{
    public  class DzinsaiPage : PageBase
    {
        private IWebElement _filtroMygtukas => _driver.FindElement(By.CssSelector(".shij32-2.kArbSO"));
        private IWebElement _rodytiRezultatus => _driver.FindElement(By.XPath("//*[@id='app']/section/div[5]/div[3]/button[2]"));
        private IWebElement _spalvosFiltrasMelyna => _driver.FindElement(By.Id("38920"));
        private IWebElement _paieskosDzinsaiRezultatoLaebl => _driver.FindElement(By.XPath("//main[@id='app']/section/section/div[2]/div/div/div/div/div/span"));
        private IWebElement _paieskosSuFiltraisRezultatuSkaicius => _driver.FindElement(By.XPath("//*[@id='app']/section/section/div[2]/div[1]/div/div/div/div[1]/span/span"));
        private IWebElement _modelioFiltrasVienspalves => _driver.FindElement(By.Id("35005"));
        private IWebElement _pritaikomumoFiltrasSiauros => _driver.FindElement(By.Id("35064"));
        private IWebElement _pritaikomumoFiltrasPlacios => _driver.FindElement(By.Id("35273"));
        private By _countrySelectLocator => By.XPath("//*[@id='app']/div/div[2]/span/div[2]/strong");
        public DzinsaiPage(IWebDriver inputDriver) : base(inputDriver) { }

        public DzinsaiPage EitiIDzinsuPuslapi()
        {
            _driver.Url = "https://www.aboutyou.lt/moterims/drabuziai/dzinsai?is_s=none&is_h=gz&term=dzinsais";

            return this;
        }

        public DzinsaiPage PridetiCookie()
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
        public DzinsaiPage SelectCountry()
        {
            var elements = _driver.FindElements(_countrySelectLocator);

            if (elements.Count > 0) 
            {
                elements.First().Click(); 
            }

            return this;
        }


        public DzinsaiPage EitiIFiltrus()
        {
            _filtroMygtukas.Click();

            return this;
        }
        public DzinsaiPage SpalvosPasirinkimas()
        {
            Actions action = new Actions(_driver);

            action.MoveToElement(_spalvosFiltrasMelyna).Build().Perform();

            if (!_spalvosFiltrasMelyna.Selected)
                _spalvosFiltrasMelyna.Click();

            return this;
        }
        public DzinsaiPage ModelioPasirinkimas()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_modelioFiltrasVienspalves).Build().Perform();

            if (!_modelioFiltrasVienspalves.Selected)
                _modelioFiltrasVienspalves.Click();

            return this;
        }
        public DzinsaiPage PritaikomumoPasirinkimas()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_pritaikomumoFiltrasSiauros).Build().Perform();

            if (!_pritaikomumoFiltrasSiauros.Selected)
                _pritaikomumoFiltrasSiauros.Click();
            if (!_pritaikomumoFiltrasPlacios.Selected)
                _pritaikomumoFiltrasPlacios.Click();

            return this;
        }

        public DzinsaiPage RodytiRezultatus()
        {
            _rodytiRezultatus.Click();
            return this;
        }


        public DzinsaiPage PatikrintiRezultatuKieki(int expectedResult)
        {
            string Originalrezultatas = _paieskosSuFiltraisRezultatuSkaicius.Text;
            int rezultatuSkaicius = Convert.ToInt32(Originalrezultatas);

            Assert.GreaterOrEqual(rezultatuSkaicius, expectedResult);

            return this;
        }
        public DzinsaiPage PatikrintiArPaieskaNuvedeIDzinsuPuslapi()
        {
            GetWait()
            .Until(ExpectedConditions.ElementExists(By.XPath("//main[@id='app']/section/section/div[2]/div/div/div/div/div/span")));

            Assert.True(_paieskosDzinsaiRezultatoLaebl.Text.Contains("Džinsai"), "Dzinsu paieska sekminga");

            return this;

        }
    }
}
