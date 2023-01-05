using CorePageObjectTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CorePageObjectTests.Util;
using System;
using System.Threading;

namespace CorePageObjectTests.Tests
{
    public class AllTests : BaseTest
    {
        [Test]
        public void FilterCampersBySelectingLocation()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            BookTripPageObject bookTripPage = new BookTripPageObject(driver);

            // if need
            //mainPage.ClosePopUpWindow();

            mainPage.ClickOnBookATrip();

            JSUtil.Scroll(driver, 950);

            Thread.Sleep(600);

            bookTripPage.GoToTheNestedIframe()
                .SetActiveTempeLocation();

            int numberOfCampers = bookTripPage.GetListCampersWithLocationTempe().Count;
            int expectedNumberOfCampers = bookTripPage.GetListAllCampers().Count;
            Assert.AreEqual(expectedNumberOfCampers, numberOfCampers, 
                $"{expectedNumberOfCampers} is not equal to {numberOfCampers}");
        }

        [Test]
        public void ChangingTheLanguageFromEnglishToGerman()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            BookTripPageObject bookTripPage = new BookTripPageObject(driver);

            // if need
            //mainPage.ClosePopUpWindow();

            mainPage.ClickOnBookATrip();

            JSUtil.Scroll(driver, 950);

            bookTripPage.GoToTheNestedIframe()
                .OpenTheListOfLanguages()
                .ChooseGermanyLanguage();

            string GermanCurrency = bookTripPage.GetStringInGermany();
            Assert.IsTrue(GermanCurrency.Equals("Fahrzeugtyp"));
        }



        [Test]
        public void ChoosingCalendarDaysToRentCamper()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            BookTripPageObject bookTripPage = new BookTripPageObject(driver);
            mainPage.ClickOnBookATrip();

            JSUtil.Scroll(driver, 950);

            bookTripPage.GoToTheNestedIframe()
                .OpenCalendar()
                .SelectAnyCamperInTheCalendar()
                .GetRentedIntervalInTheCalendar();
            Assert.IsTrue(true);
        }

        [Test]
        public void ChangeCalendarToWeek()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            BookTripPageObject bookTripPage = new BookTripPageObject(driver);
            mainPage.ClickOnBookATrip();

            JSUtil.Scroll(driver, 950);

            bookTripPage.GoToTheNestedIframe()
                .OpenCalendar()
                .ChooseWeek();
            Assert.IsTrue(bookTripPage.GetStringInMonth().Equals("Dec 25 – 31, 2022"));
        }

        [Test]
        public void CheckFinancingCalculator()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            mainPage.ClickOnFinancing();

            FinancingPageObject financingPage = new FinancingPageObject(driver);

            JSUtil.Scroll(driver, 950);

            financingPage.GoToTheNestedIframe();
            string lastEstimated = financingPage.GetResultEstimated();

            financingPage.ChooseProjectCostField()
                .InputProjectCostField()
                .ChooseCreditScore()
                .ChooseCreditScorePoor();

            Assert.IsFalse(lastEstimated.Equals("$29.83"));
        }

        [Test]
        public void CheckTheSlider()
        {
            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenPage();
            mainPage.ClickOnBuy();

            BuyPageObject buyPage = new BuyPageObject(driver);

            JSUtil.Scroll(driver, 4000);

            buyPage.MoveNextImageButton().ClickNextImageButton();

            Assert.IsTrue(buyPage.CheckHiddenImage());
        }
    }
}
