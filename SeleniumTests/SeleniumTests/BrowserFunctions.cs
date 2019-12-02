using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTests
{
    public abstract class BrowserFunctions
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
        public void CloseBrowser()
        {
            webDriver.Quit();
        }

        protected IWebElement GetWebElementById(string Id)
        {
            return webDriver.FindElement(By.Id(Id));
        }
        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
