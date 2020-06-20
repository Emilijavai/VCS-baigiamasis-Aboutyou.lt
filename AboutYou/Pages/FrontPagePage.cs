using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AboutYou.Pages
{
    public class FrontPagePage :PageBase
    {
        private IWebElement _moteriskuDrabuziuMygtukas => _driver.FindElement(By.LinkText("Į moteriškų prekių parduotuvę"));
        private IWebElement _eitiISuknelesMygtukasAntFoto => _driver.FindElement(By.LinkText("Suknelės"));
        private IWebElement _pasirinktiSijona => _driver.FindElement(By.Id("4019247"));
        private IWebElement _sijonoDydis => _driver.FindElement(By.XPath("//*[@id='app']/section/section[1]/section/div[2]/div/div/div/div[6]/div[1]/div/div[2]/div[3]"));

        private IWebElement _iKrepseliIdetiPreke => _driver.FindElement(By.CssSelector(".sc-1hcxzn2-0"));
        private IWebElement _iPrekiuKrepseliEiti => _driver.FindElement(By.LinkText("Į prekių krepšelį"));
        private IWebElement _prekesKaina => _driver.FindElement(By.XPath("//*[@id='app']/section/div[3]/div[1]/div/div/div/div/div[1]/div/div[2]/div")); //39,90
        private IWebElement _kiekisKrepselyjeDropDown => _driver.FindElement(By.XPath("//*[@id='app']/section/div[3]/div[1]/section/ul/li/ul/li/div/div[2]/div[1]/div[1]/div/button"));
        private IWebElement _kiekisKrepselyjeDu => _driver.FindElement(By.XPath("//*[@id='app']/section/div[3]/div[1]/section/ul/li/ul/li/div/div[2]/div[1]/div[1]/div/div/div[2]/div"));
        private IWebElement _eitiIMarskineliaiAntPagrindesFoto => _driver.FindElement(By.LinkText("Marškinėliai"));
        private IWebElement _marskineliaiRezultatoLabel => _driver.FindElement(By.XPath("//*[@id='app']/section/section/div[1]/div/div/nav/ul/a[3]/li/span"));
        private IWebElement _paskyrosMygtukas => _driver.FindElement(By.ClassName("_userIcon_e381b"));
        private IWebElement _atsijungtiMygtukas => _driver.FindElement(By.XPath("//*[@id='app']/section/div[2]/div/header/div/div[1]/div[3]/ul/li[2]/div/div/ul/li[3]/button/span"));
        private IWebElement _paieskosMygtukas => _driver.FindElement(By.XPath("//main[@id='app']/section/div[2]/div/header/div/div/div[3]/ul/li/div/div/form/button"));
        private IWebElement _ivestiPaieskosTeksta => _driver.FindElement(By.XPath("//input"));
        private IWebElement _prekiuZenklaiMygtukas => _driver.FindElement(By.LinkText("Prekių ženklai"));
        private IWebElement _prekesZenklasONLY => _driver.FindElement(By.ClassName("_brandLink_f84ea"));
        private IWebElement _prekiuZenkloRezultatoLabel => _driver.FindElement(By.XPath("//*[@id='app']/section/section/div[2]/div[3]/div/div/div/div[1]/span"));
        private By _countrySelectLocator => By.XPath("//*[@id='app']/div/div[2]/span/div[2]/strong");
        private IWebElement _pagrindineJuosta => _driver.FindElement(By.ClassName("_animatedUnderline_62dab"));

        public FrontPagePage(IWebDriver inputDriver) : base(inputDriver) { }

        public FrontPagePage EitiIPagrindiniPuslapi()
        {
            _driver.Url = "https://www.aboutyou.lt/";
            _driver.Manage().Window.Maximize();

            return this;
        }
        public FrontPagePage PridetiCookie()
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

        public FrontPagePage SelectCountry()
        {
            var elements = _driver.FindElements(_countrySelectLocator);

            if (elements.Count > 0)
            {
                elements.First().Click();
            }
            return this;
        }

        public FrontPagePage PatikrintiArLoggedIn()
        {
            GetWait(30)
            .Until(ExpectedConditions.ElementExists(By.ClassName("_animatedUnderline_62dab")));

            _paskyrosMygtukas.Click();
            Assert.True(_atsijungtiMygtukas.Text.Contains("Atsijungti"), "You are not logged in");

            return this;
        }

        public FrontPagePage PasirinktiSijonaIrDydi()
        {
            Actions actions = new Actions(_driver);
            GetWait()
                .Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/section/section/div[2]/div[3]/div/div/div/div[1]/span")));

            _pasirinktiSijona.Click();

            GetWait()
                  .Until(ExpectedConditions.ElementExists(By.CssSelector(".iay39c-1.jQkeOg")));
            //cia pradejo mesti klaida 'stale element reference: element is not attached to the page document".
            //pagooglinau, kad pataria susikurti local elementus metoduose su string. Padariau nu ir pavyko.
            //tik nezinau ar cia geras budas?


            string xpath = "//*[@id='app']/section/section[1]/section/div[2]/div/div/div/div[6]/div[1]/div/div[2]/div[2]";
            _driver.FindElement(By.XPath(xpath));
            _sijonoDydis.Click();

            string krepselis = ".sc-1hcxzn2-0";
            _driver.FindElement(By.CssSelector(krepselis));
            _iKrepseliIdetiPreke.Click();

            GetWait().Until(ExpectedConditions.ElementExists(By.LinkText("Į prekių krepšelį")));

            string eititIKrepseli = "Į prekių krepšelį";
            _driver.FindElement(By.LinkText(eititIKrepseli));

            _iPrekiuKrepseliEiti.Click();

            return this;
        }

        public FrontPagePage PatikrintiSijonoKaina(string expectedKaina)
        {
            GetWait()
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/section/div[3]/div[1]/div/div/div/div/div[1]/div/div[2]/div")));

            Assert.True(_prekesKaina.Text.Contains(expectedKaina), $"Suma negera, turi buti {expectedKaina} ");

            return this;
        }

        public FrontPagePage PadidintiSijonuKiekiKrepselyje()
        {

            _kiekisKrepselyjeDropDown.Click();
            _kiekisKrepselyjeDu.Click();

            Thread.Sleep(3000);

            return this;
        }

        

        public DzinsaiPage IeskotiDzinsu()
        {
            _paieskosMygtukas.Click();
            _ivestiPaieskosTeksta.SendKeys("dzinsai");

            _ivestiPaieskosTeksta.SendKeys(Keys.Enter);

            return new DzinsaiPage(_driver);
        }

        public FrontPagePage PasirinktiPrekiuZenkla()
        {
            _prekiuZenklaiMygtukas.Click();

            Actions actions = new Actions(_driver);

            actions.MoveToElement(_prekesZenklasONLY).Build().Perform();
            _prekesZenklasONLY.Click();

            return this;
        }
        public FrontPagePage PatikrintiPrekiuZenkloPuslapioRezultatoLabel()
        {
            GetWait()
            .Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/section/section/div[2]/div[3]/div/div/div/div[1]/span")));

            Assert.True(_prekiuZenkloRezultatoLabel.Text.Contains("Visi produktai iš ONLY"), "Puslapis nera prekiu zenklo ONLY");

            return this;

        }

        public FrontPagePage PaspaustiAntPagrindinesNuotraukos()
        {
            _moteriskuDrabuziuMygtukas.Click();
            _eitiIMarskineliaiAntPagrindesFoto.Click();
            return this;
        }
        public FrontPagePage PatikrintMarskineliuFiltra(string expectedFiltras)
        {
            GetWait()
            .Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/section/section/div[1]/div/div/nav/ul/a[3]/li/span")));

            Assert.True(_marskineliaiRezultatoLabel.Text.Contains(expectedFiltras));
            return this;
        }
    }
}
