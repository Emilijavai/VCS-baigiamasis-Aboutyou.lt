using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Tests
{
    public class DzinsaiTest : TestBase
    {
        [TestCase(TestName = "Pasirenkam prekes filtrus ir patikrinam paiekos rezultatu skaiciu")]
        public static void DzinsuFiltruTestas()
        {
            _dzinsaiPage
               .EitiIDzinsuPuslapi()
               .PridetiCookie()
               .SelectCountry()
               .EitiIFiltrus()
               .SpalvosPasirinkimas()
               .ModelioPasirinkimas()
               .PritaikomumoPasirinkimas()
               .RodytiRezultatus()
               .PatikrintiRezultatuKieki(700);



        }

    }
}
