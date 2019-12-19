using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Lab7Test.Driver
{
   
    public class DriverSingleton
    {
        private static IWebDriver Driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        Driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                        break;
                }
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            return Driver;
        }

        public static void CloseDriver()
        {
            Driver.Quit();
            Driver = null;
        }

    }
}




