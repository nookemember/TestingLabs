using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://e-kvytok.kiev.ua/ru/gd/");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        // Найти билет, не указав дату.
        //-зайти на https://e-kvytok.kiev.ua/ru/gd/
        //-откуда: Киев
        //-куда: Москва
        //-дата: поле оставить пустым
        //-нажать "найти"
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithEmptyFieldDepartureDate()
        {
            var homepage = new KvytokHomePage(webDriver);

            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Москва";
            const string expectedErrorMessage = "Это поле необходимо заполнить";
            #endregion

            homepage.ChoiceDepartureCity(departureCityText);
            homepage.ChoiceArriveCity(arriveCityText);
            homepage.searchButton.Click();

            Assert.AreEqual(expectedErrorMessage, homepage.GetErrorMessage());
        }

        // Найти билет, указав вчерашнюю дату
        //-зайти на https://e-kvytok.kiev.ua/ru/gd/
        //-откуда: Киев
        //-куда: Москва
        //-дата: вчерашняя
        //-нажать "найти"
        //
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithYeasterdayDate()
        {
            var homepage = new KvytokHomePage(webDriver);
            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Москва";
            const string expectedErrorMessage = "Это поле необходимо заполнить";
            int yesterday = DateTime.Now.Day - 1;
            #endregion

            homepage.ChoiceDepartureCity(departureCityText);
            homepage.ChoiceArriveCity(arriveCityText);
            homepage.OpenCalendar();
            var dates = homepage.GetCalendarDates();
            var day = dates.FirstOrDefault(d => d.Text.Equals(yesterday.ToString()));
            day.Click();
            homepage.searchButton.Click();

            Assert.AreEqual(expectedErrorMessage, homepage.GetErrorMessage());
        }
    }
}
