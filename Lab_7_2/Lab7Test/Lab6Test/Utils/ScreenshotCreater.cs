using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Test.Utils
{
    public class ScreenshotCreater
    {
        public static void SaveScreenShot(IWebDriver webDriver)
        {
            ITakesScreenshot scrShot = ((ITakesScreenshot)webDriver);
            DirectoryInfo directory = Directory.CreateDirectory(@"screenshots\" + DateTime.Now.ToString("dd_MM_yyyy") + @"\");
            scrShot.GetScreenshot().SaveAsFile(directory.FullName + @"\" + DateTime.Now.ToString("HH_mm_ss") + ".png", ScreenshotImageFormat.Png);
        }
    }
}
