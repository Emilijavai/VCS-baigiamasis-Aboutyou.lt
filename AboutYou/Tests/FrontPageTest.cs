using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutYou.Tests
{
   public  class FrontPageTest :TestBase
    {
        [TestCase("Marškinėliai", TestName = "Paspausti and pagrindines nuotraukos - marskineliai - paziureti ar atidarys tinkama puslapi")]

        public static void MarskineliaiNuotraukostestas(string filtras)
        {
            _frontPagePage
                .EitiIPagrindiniPuslapi()
                .PridetiCookie()
                .SelectCountry()
                .PaspaustiAntPagrindinesNuotraukos()
                .PatikrintMarskineliuFiltra(filtras);
        }

        [TestCase(TestName ="Pridedam preke, patikrinam ar krepselyje keiciant kieki keiciasi ir kaina atitinkamai")]
        public static void IsidetiSukneleIKrepseliTestas()
        {
            _frontPagePage
                .EitiIPagrindiniPuslapi()
                .PridetiCookie()
                .SelectCountry()
                .PasirinktiPrekiuZenkla()
                .PasirinktiSijonaIrDydi()
                .PatikrintiSijonoKaina("22,90 EUR")
                .PadidintiSijonuKiekiKrepselyje()
                .PatikrintiSijonoKaina("45,80 EUR");
            
        }

        [TestCase(TestName = "Ivedam i paieska - dzinsai,patikrinam ar atidaro dzinsu puslapi")]
        public static void DzinsuPaieskosTestas()
        {
            _frontPagePage
                .EitiIPagrindiniPuslapi()
                .PridetiCookie()
                .SelectCountry()
                .IeskotiDzinsu();
            _dzinsaiPage
                .PatikrintiArPaieskaNuvedeIDzinsuPuslapi();
        }

        [TestCase(TestName ="Pasirenkam prekes zenkla - ONLY, patikrinam ar nuveda i ONLY prekes zenklo puslapi")]
        public static void PrekiuZenkloTestas()
        {
            _frontPagePage
                .EitiIPagrindiniPuslapi()
                .PridetiCookie()
                .SelectCountry()
                .PasirinktiPrekiuZenkla()
                .PatikrintiPrekiuZenkloPuslapioRezultatoLabel();
        }

    }
}
