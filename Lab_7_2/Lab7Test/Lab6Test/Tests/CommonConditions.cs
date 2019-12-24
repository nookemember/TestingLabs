using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Lab7Test.Driver;
using NUnit.Framework.Interfaces;
using Lab7Test.Utils;


namespace Lab7Test.Tests
{
    public class CommonConditions
    {
        protected IWebDriver Driver;

        [SetUp]
        public void OpenBrowser()
        {
            Driver = DriverSingleton.GetDriver();       
        }

        [TearDown]
        public void TearDownTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotCreater.SaveScreenShot(Driver);
            }

            DriverSingleton.CloseDriver();
        }

    }

}
