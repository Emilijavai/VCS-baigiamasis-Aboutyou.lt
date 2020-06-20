using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Tests
{
   public class LogInTest :TestBase
    {
        [TestCase("vaiksnytemilija@gmail.com", "Em.l.ja1", TestName = "Tikriname ar pavyksta prisijungti su esama paskyra")]
        public static void PrisijungtiPriePaskyrosTest(string email, string password)
        {
            _logInPage.AtidarytiPagrindiPuslapi()
                .PridetiCookie()
                .SelectCountry()
                .EitiILogInPuslapi()
                .AtliktiPrisijungimaPriePaskyros(email, password);
            _frontPagePage.PatikrintiArLoggedIn();

        }
    }
}
