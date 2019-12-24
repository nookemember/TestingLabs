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
        [Test]
        [Category("SearchTest")]
        public void FindTrainWithoutDate()
        {
            #region TestData
            const string NoDateError = "Это поле необходимо заполнить";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            MainPage findTrainWithoutDate = new MainPage(Driver);

            findTrainWithoutDate
                .FillFieldFrom(route)
                .Submit();

            Assert.AreEqual(findTrainWithoutDate.CheckWithoutDateError(), NoDateError);
        }
        [Test]
        [Category("ValidationTest")]
        public void BuyTicketWithoutAllData()
        {
            #region TestData
            const string ERA = "Это поле необходимо заполнить";
            #endregion

            Route route = RouteCreator.WithAllPropertiesJitomir();
            MainPage fillFormsRoute = new MainPage(Driver);
            SelectTrainPage selectOther = new SelectTrainPage(Driver);
            fillFormsRoute
                .FillFieldFrom(route)
                .SelectTodayDate()
                .Submit();
            selectOther
                .FillForm()
                .BuyTicket();

            Assert.AreEqual(selectOther.CheckError(), ERA);
        }
        [Test]
        [Category("ValidationTest")]
        public void BuyTicketWithIncorrectEmail()
        {
            #region TestData
            const string ERA = "Пожалуйста, введите корректный адрес электронной почты";
            #endregion

            Route route = RouteCreator.WithAllPropertiesJitomir();
            User user = UserCreator.WrongEmail();
            MainPage fillFormsRoute = new MainPage(Driver);
            SelectTrainPage selectOther = new SelectTrainPage(Driver);
            fillFormsRoute
            .FillFieldFrom(route)
            .SelectTodayDate()
            .Submit();
            selectOther
                .FillForm()
                .FillUserForm(user)
                .BuyTicket();

            Assert.AreEqual(selectOther.CheckError(), ERA);
        }
        [Test]
        [Category("ValidationTest")]
        public void BuyTicketWithIncorrectPhoneNumber()
        {
            #region TestData
            const string ERA = "Пожалуйста, введите корректный номер телефона";
            #endregion

            Route route = RouteCreator.WithAllPropertiesJitomir();
            User user = UserCreator.WrongNumber();
            MainPage fillFormsRoute = new MainPage(Driver);
            SelectTrainPage selectOther = new SelectTrainPage(Driver);
            fillFormsRoute
            .FillFieldFrom(route)
            .SelectTodayDate()
            .Submit();
            selectOther
                .FillForm()
                .FillUserForm(user)
                .BuyTicket();

            Assert.AreEqual(selectOther.CheckError(), ERA);
        }
        [Test]
        [Category("ValidationTest")]
        public void BuyTicketWithoutTermsOfAnAgreement()
        {
            #region TestData
            const string ERA = "Нам нужно Ваше согласие с условиями договора";
            #endregion

            Route route = RouteCreator.WithAllPropertiesJitomir();
            User user = UserCreator.CorrectParameters();
            MainPage fillFormsRoute = new MainPage(Driver);
            SelectTrainPage selectOther = new SelectTrainPage(Driver);
            fillFormsRoute
            .FillFieldFrom(route)
            .SelectTodayDate()
            .Submit();
            selectOther
                .FillForm()
                .FillUserForm(user)
                .BuyTicket();

            Assert.AreEqual(selectOther.CheckError(), ERA);
        }
        [Test]
        [Category("AutorisationTest")]
        public void AutorisationFail()
        {
            #region TestData
            const string ERA = "Вам не удалось авторизоваться. Для ознакомления с возможными причинами, перейдите по ссылке";
            #endregion

            Autorisation autorisation = AutorisationCreator.WrongEmail();
            MainPage mainPage = new MainPage(Driver);
            mainPage
                .MyTicket()
                .AutorisationFields(autorisation);

            Assert.AreEqual(mainPage.AutorisationErrorCheck(), ERA);
        }
        [Test]
        [Category("AutorisationTest")]
        public void AutorisationAccept()
        {
            #region TestData
            const string ERA = "Здравствуйте, Ясковец Никита! Мы рады Вас видеть!";
            #endregion

            Autorisation autorisation = AutorisationCreator.RightParameters();
            MainPage mainPage = new MainPage(Driver);
            mainPage
                .MyTicket()
                .AutorisationFields(autorisation)
                .MyTicket2();
               
                
            Assert.AreEqual(mainPage.CheckLogOutText(), ERA);
        }
        [Test]
        [Category("ValidationTest")]
        public void BuyTicketWithNoCVVCode()
        {
            #region TestData
            const string ERA = "Введите корректные данные.";
            #endregion

            Route route = RouteCreator.WithAllPropertiesJitomir();
            User user = UserCreator.CorrectParameters();
            MainPage fillFormsRoute = new MainPage(Driver);
            Autorisation autorisation = AutorisationCreator.RightParameters();
            SelectTrainPage selectOther = new SelectTrainPage(Driver);
            Payment payment = PaymentCreator.AllCorrect();
            PaymentPage paymentPage = new PaymentPage(Driver);
            MainPage mainPage = new MainPage(Driver);
            mainPage
                .MyTicket()
                .AutorisationFields(autorisation);
            fillFormsRoute
                .FillFieldFrom(route)
                .SelectTodayDate()
                .Submit();
            selectOther
                .FillForm()
                .FillUserForm(user)
                .AcceptIATA()
                .BuyTicket()
                .BuyBuyTicket();
            paymentPage
                .FillForm(payment)
                .CompleteOrder();
            Assert.AreEqual(paymentPage.NoCVVErrorMessage(), ERA);
        }
    }
}
