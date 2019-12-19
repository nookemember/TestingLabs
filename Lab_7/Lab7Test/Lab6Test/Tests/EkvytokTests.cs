using System;
using NUnit.Framework;
using Lab7Test.Pages;
using Lab7Test.Tests;
using Lab7Test.Models;
using Lab7Test.Services;

namespace Lab7Test
{
    [TestFixture]
    public class EkvytokTests : CommonConditions
    {

        [Test]
        [Category("SearchTest")]
        public void FindTrainWithoutDepartureCity()
        {
            #region TestData
            const string bookingWithoutDepCityErrorMessage = "Это поле необходимо заполнить";
            #endregion
            
                Route route = RouteCreator.WithAllProperties();
                MainPage bookingWithoutDestination = new MainPage(Driver);

                    bookingWithoutDestination
                    .FillWithoutDepCity(route)
                    .SelectTodayDate()
                    .Submit();

                Assert.AreEqual(bookingWithoutDestination.CheckErrorBookingWithoutDepartmentCity(), bookingWithoutDepCityErrorMessage);
        }

        [Test]
        [Category("PositiveTest")]
        public void RightParametersServerError()
        {
            #region TestData
            const string expectedErrorMessage = "На сервере произошла ошибка, пожалуйста, попробуйте позже. Если ситуация повторится, обратитесь в Службу поддержки.";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            MainPage searchWithWrongReservationCode = new MainPage(Driver);

            searchWithWrongReservationCode
                .FillFieldFrom(route)
                .SelectTodayDate()
                .Submit();
                
            Assert.AreEqual(searchWithWrongReservationCode.CheckServerError(), expectedErrorMessage);

        }

    }
}
