using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    class KvytokHomePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//table[@class='ui-datepicker-calendar']")]
        private IWebElement calendar;

        public KvytokHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public IWebElement arriveCity => GetWebElementById("to_name");

        public IWebElement departureCity => GetWebElement("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[1]/input[1]");

        public IWebElement searchButton => GetWebElement("/html/body/div[1]/section[1]/div/div[1]/form/div[4]/button");

        public void ChoiceDepartureCity(string city)
        {
            departureCity.SendKeys(city);
            IWebElement _departureCity = GetWebElement("/html/body/ul[1]/li[1]/a");
            _departureCity.Click();
        }

        public void ChoiceArriveCity(string city)
        {
            arriveCity.SendKeys(city);
            IWebElement _arriveCity = GetWebElement("/html/body/ul[2]/li[1]/a");
            _arriveCity.Click();
        }

        public string GetErrorMessage()
        {
            return GetWebElement("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[4]/samp").Text;
        }

        public IEnumerable<IWebElement> GetCalendarDates()
        {
            var datesList = GetWebElement("//table[@class='ui-datepicker-calendar']");
            return datesList.FindElements(By.XPath("//a"));
        }

        public void OpenCalendar()
        {
            calendar.Click();
        }

        private IWebElement GetWebElement(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath));
        }

        private IWebElement GetWebElementById(string Id)
        {
            return _driver.FindElement(By.Id(Id));
        }
    }
}
