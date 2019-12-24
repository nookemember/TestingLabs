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

        [FindsBy(How = How.XPath, Using = "//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[5]/td[5]")]
        private IWebElement DateCalendarSelectDate;

        [FindsBy(How = How.XPath, Using = "//*[@id='alert_popup']/div[2]/p")]
        private IWebElement ServerError;

        [FindsBy(How = How.XPath, Using = "//*[@id='page']/section[1]/div/div[1]/form/div[3]/div/div[4]/samp")]
        private IWebElement NoDateError;

        [FindsBy(How = How.XPath, Using = "//*[@id='email_login']")]
        private IWebElement UserLogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='pass_login']")]
        private IWebElement UserPassword;

        [FindsBy(How = How.XPath, Using = "//*[@class='form-submit']")]
        private IWebElement SignInButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='error _idx_0']")]
        private IWebElement AutorisationError;

        [FindsBy(How = How.XPath, Using = "//*[@id='header']/div/div/div/div[3]/a[1]")]
        private IWebElement MyTicketButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='header']/div/div/div/div[3]/a[2]")]
        private IWebElement MyTicketButton2;

        [FindsBy(How = How.XPath, Using = "//*[@id='page']/div[1]/div/div/div[1]")]
        private IWebElement AAA;

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
        public MainPage MyTicket()
        {
            MyTicketButton.Click();
            return this;
        }
        public MainPage MyTicket2()
        {
            MyTicketButton2.Click();
            return this;
        }

        public MainPage AutorisationFields(Autorisation autorisation)
        {
            
            UserLogin.SendKeys(autorisation.Email);
            UserPassword.SendKeys(autorisation.Password);
            SignInButton.Click();
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
        public string CheckLogOutText()
        {
            return AAA.Text;
        }

        public string AutorisationErrorCheck()
        {
            return AutorisationError.Text;
        }

        public string CheckServerError()
        {
            return ServerError.Text;
        }
        public string CheckWithoutDateError()
        {
            return NoDateError.Text;
        }

        public string CheckErrorBookingWithoutDepartmentCity()
        {
            return BookingWithoutDepCityErrorLabel.Text;
        }

    }
}
