using System;
using NUnit.Framework;
    
namespace SeleniumTests
{
    [TestFixture]
    public class Tests : BrowserFunctions
    {
        // Найти билет, не указав дату.
        //-зайти на https://e-kvytok.kiev.ua/ru/gd/
        //-откуда: Москва
        //-куда: Киев
        //-дата: поле оставить пустым
        //
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithEmptyFieldDepartureDate()
        {
            #region TestData
            const string departureCityText = "Москва";
            const string arriveCityText = "Киев";
            #endregion

            var departureCity = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[1]/input[1]");
            departureCity.SendKeys(departureCityText);
            var departureCityInList = GetWebElementByXPath("/html/body/ul[1]/li[1]/a");
            departureCityInList.Click();

            var arriveCity = GetWebElementById("to_name");
            arriveCity.SendKeys(arriveCityText);
            var arriveCityInList = GetWebElementByXPath("/html/body/ul[2]/li[1]/a");
            arriveCityInList.Click();

            var searchButton = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[4]/button");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[4]/samp");

            Assert.AreEqual("Это поле необходимо заполнить", errorMessage.Text);
        }

        // Найти билет, указав вчерашнюю дату
        //-зайти на https://e-kvytok.kiev.ua/ru/gd/
        //-откуда: Москва
        //-куда: Киев
        //-дата: вчерашняя
        //-нажать "найти"
        //
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithYeasterdayDate()
        {
            #region TestData
            const string departureCityText = "Москва";
            const string arriveCityText = "Киев";
            int yesterday = DateTime.Now.Day - 1;
            #endregion

            var departureCity = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[1]/input[1]");
            departureCity.SendKeys(departureCityText);
            var departureCityInList = GetWebElementByXPath("/html/body/ul[1]/li[1]/a");
            departureCityInList.Click();

            var arriveCity = GetWebElementById("to_name");
            arriveCity.SendKeys(arriveCityText);
            var arriveCityInList = GetWebElementByXPath("/html/body/ul[2]/li[1]/a");
            arriveCityInList.Click();

            string xPath = ".//td[@class = ' ui-datepicker-unselectable ui-state-disabled day_td date_1575234000000']/span[@class = 'ui-state-default' and text() = '" + yesterday.ToString() + "']";
            var yesterdayDate = GetWebElementByXPath(xPath);
            yesterdayDate.Click();

            var searchButton = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[4]/button");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("/html/body/div[1]/section[1]/div/div[1]/form/div[3]/div/div[4]/samp");

            Assert.AreEqual("Это поле необходимо заполнить", errorMessage.Text);
        }
    }
}
