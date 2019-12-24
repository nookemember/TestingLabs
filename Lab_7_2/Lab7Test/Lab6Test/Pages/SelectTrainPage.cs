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
    class SelectTrainPage
    {
        private IWebDriver Driver;

       

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[3]/div/ul[2]/li/div[2]/ul/li[2]/a")]
        private IWebElement SelectKupe;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[3]/div/ul[2]/li/div[4]/ul[2]/li[2]/div[3]/div[1]/div/ins")]
        private IWebElement SelectCoach;

        [FindsBy(How = How.XPath, Using = "//*[@class='top']")]
        private IWebElement SelectNumber;

        [FindsBy(How = How.XPath, Using = "//*[@data-uil='first_name']")]
        private IWebElement UserFirstName;

        [FindsBy(How = How.XPath, Using = "//*[@data-uil='surname']")]
        private IWebElement UserLastName;

        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        private IWebElement UserEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='phone_number']")]
        private IWebElement UserPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//*[@class='error']")]
        private IWebElement ER;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[3]/div/ul[2]/li/div[4]/div/form/div[2]/div[8]/div/div[2]/input")]
        private IWebElement BuyButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='acceptIATA']/div/ins")]
        private IWebElement TermsOfAnAgreement;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[2]/form/div/p/input")]
        private IWebElement SubmitInformationButton;

        public SelectTrainPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            
        }
        public SelectTrainPage FillForm()
        {
            SelectKupe.Click(); 
            SelectCoach.Click();
            SelectNumber.Click();
            return this;
        }
        public SelectTrainPage AcceptIATA()
        {
            TermsOfAnAgreement.Click();
            return this;
        }
        public SelectTrainPage FillUserForm(User user)
        {
            UserFirstName.SendKeys(user.FirstName);
            UserLastName.SendKeys(user.LastName);
            UserEmail.SendKeys(user.Email);
            UserPhoneNumber.SendKeys(user.PhoneNumber);
            return this;
        }
        public SelectTrainPage BuyTicket()
        {
            BuyButton.Click();
            return this;
        }
        public SelectTrainPage BuyBuyTicket()
        {
            SubmitInformationButton.Click();
            return this;
        }
        public string CheckError()
        {
            return ER.Text;
        }
        
    }
}
