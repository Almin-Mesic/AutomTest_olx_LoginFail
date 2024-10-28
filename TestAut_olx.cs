using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AT_OLX
{
    [TestFixture]
    class Program
    {
        // Open chrome
        private IWebDriver driver; // = new ChromeDriver();


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void Test()
        {
            // Go to Google
            driver.Navigate().GoToUrl("https://www.olx.ba");

            // Fullscreen
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            // Ad 
            IWebElement SlazemSe = driver.FindElement(By.ClassName("css-1sjubqu"));
            SlazemSe.Click();
            Thread.Sleep(10000);

            // Categories
            IWebElement Kategorije = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/div[2]/div[1]/div/a[1]/div/img"));
            Kategorije.Click();
            Thread.Sleep(3000);

            // Condos and Apartments
            IWebElement StanIApart = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/div[2]/div[2]/div/a[1]"));
            StanIApart.Click();
            Thread.Sleep(3000);

            // Post something
            IWebElement ObjaviOglas = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/header/div/div[1]/div[2]/div/button/div"));
            //var selectElementLokacija = new SelectElement(lokacija);
            ObjaviOglas.Click();
            Thread.Sleep(3000);

            // Name
            IWebElement KorisnickoIme = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[2]/div[2]/div[1]/div[1]/div/input"));
            KorisnickoIme.Click();
            Thread.Sleep(3000);

            IWebElement UpisanoIme = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[2]/div[2]/div[1]/div[1]/div/input"));
            UpisanoIme.SendKeys("Testtt");
            Thread.Sleep(3000);

            // Password
            IWebElement TrazenaSifra = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[2]/div[2]/div[1]/div[2]/div/input"));
            TrazenaSifra.Click();
            Thread.Sleep(3000);

            IWebElement UpisanaSifra = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[2]/div[2]/div[1]/div[2]/div/input"));
            UpisanaSifra.SendKeys("123456789");
            Thread.Sleep(3000);

            // Login button
            IWebElement PrijaviSe = driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[2]/div[2]/div[1]/button"));
            PrijaviSe.Click();
            Thread.Sleep(3000);

            // Podaci nisu tacni
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[4]/div/p"));
            Assert.That(errorMessage.Text.Contains("Podaci nisu tačni"));
            Thread.Sleep(3000);
        }


        [TearDown]
        public void CloseTest()
        {
            // Close broowser
            driver.Quit();
        }
    }

}