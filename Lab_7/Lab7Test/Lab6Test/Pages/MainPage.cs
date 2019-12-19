using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Lab7Test.Models;
using Lab7Test.Services;

namespace Lab7Test.Pages
{
    class MainPage
    {
        private IWebDriver Driver;

        private readonly string Url = "https://e-kvytok.kiev.ua/ru/gd/";

        [FindsBy(How = How.XPath, Using = "//*[@id='from_name_as']")]
        private IWebElement DepartureCity;

        [FindsBy(How = How.XPath, Using = "/html/body/ul[1]/li[1]/a")]
        private IWebElement DepartureCitySelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='to_name']")]
        private IWebElement ArrivalCity;

        [FindsBy(How = How.XPath, Using = "/html/body/ul[2]/li[1]/a")]
        private IWebElement ArrivalCitySelect;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/section[1]/div/div[1]/form/div[4]/button")]
        private readonly IWebElement SubmitBookingButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='page']/section[1]/div/div[1]/form/div[3]/div/div[1]/samp")]
        private IWebElement BookingWithoutDepCityErrorLabel;

        [FindsBy(How = How.XPath, Using = "//*[@id='page']/section[1]/div/div[1]/form/div[3]/div/div[4]")]
        private IWebElement DateCalendar;

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[4]/td[4]")]
        private IWebElement DateCalendarSelectDate;

        [FindsBy(How = How.XPath, Using = "//*[@id='alert_popup']/div[2]/p")]
        private IWebElement ServerError;

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            Driver.Navigate().GoToUrl(Url);
        }

        public MainPage FillWithoutDepCity(Route route)
        {
            ArrivalCity.SendKeys(route.ArrivalCity);
            ArrivalCitySelect.Click();
            return this;
        }
        public MainPage FillFieldFrom(Route route)
        {
            DepartureCity.SendKeys(route.DepartureCity);
            DepartureCitySelect.Click();
            ArrivalCity.SendKeys(route.ArrivalCity);
            ArrivalCitySelect.Click();
            return this;
        }

        public MainPage Submit()
        {
            SubmitBookingButton.Click();
            return this;
        }

        public MainPage SelectTodayDate()
        {
            DateCalendar.Click();
            DateCalendarSelectDate.Click();
            return this;
        }

        public string CheckServerError()
        {
            return ServerError.Text;
        }

        public string CheckErrorBookingWithoutDepartmentCity()
        {
            return BookingWithoutDepCityErrorLabel.Text;
        }

    }
}
