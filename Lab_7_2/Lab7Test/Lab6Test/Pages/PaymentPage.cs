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
    class PaymentPage
    {
        private IWebDriver Driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='post_card_number_1']")]
        private IWebElement CardNumber;
     
        [FindsBy(How = How.XPath, Using = "//*[@id='post_month']")]
        private IWebElement Month;

        [FindsBy(How = How.XPath, Using = "//*[@id='post_year']")]
        private IWebElement Year;

        [FindsBy(How = How.XPath, Using = "//*[@id='post_owner']")]
        private IWebElement FullName;

        [FindsBy(How = How.XPath, Using = "//*[@id='make_payment']")]
        private IWebElement CompleteOrderButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='update_attribute']/div[2]/div[2]/div[2]/div[4]")]
        private IWebElement NoCVVError;
        public PaymentPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            
        }
        public PaymentPage FillForm(Payment payment)
        {

            CardNumber.SendKeys(payment.CardNumber);
            Month.SendKeys(payment.Month);
            Year.SendKeys(payment.Year);
            FullName.SendKeys(payment.FullName);
            return this;
        }
        public PaymentPage CompleteOrder()
        {

            CompleteOrderButton.Click();
            return this;
        }
        public string NoCVVErrorMessage()
        {

            return NoCVVError.Text;
           
        }


    }
}
