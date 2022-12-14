using CorePageObjectTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.Tests
{
    public class AllTests : BaseTest
    {
        [Test]
        public void CheckCampersByLocation()
        {
            // ???????? ??????????? ???????, ???????? ?????? ??????????, ?-? ???????????? ? BaseTest
            MainPageObject mainPage = new MainPageObject(_chromeDriver);
            BookTripPageObject bookTripPage = new BookTripPageObject(_chromeDriver);

            // ????????? ??????????? ????.
            _chromeDriver.FindElement(By.XPath("//a[@class='sqs-popup-overlay-close']")).Click();

            mainPage.ClickOnBookATrip();

            bookTripPage.GoToTheNestedIframe();
            bookTripPage.SetActiveTempeLocation();

            int numberOfCampers = bookTripPage.GetListCampersWithLocationTempe().Count;
            int expectedNumberOfCampers = bookTripPage.GetListAllCampers().Count;
            Assert.AreEqual(expectedNumberOfCampers, numberOfCampers, $"{expectedNumberOfCampers} is not equal to {numberOfCampers}");
        }

        [Test]
        public void CheckComboBox()
        {
            MainPageObject mainPage = new MainPageObject(_chromeDriver);
            BookTripPageObject bookTripPage = new BookTripPageObject(_chromeDriver);

            // if need
            //mainPage.ClosePopUpWindow();

            mainPage.ClickOnBookATrip();

            IJavaScriptExecutor js = _chromeDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            bookTripPage.GoToTheNestedIframe();
            bookTripPage.OpenTheListOfLanguages();
            bookTripPage.ChooseGermanyLanguage();

            string GermanCurrency = bookTripPage.GetStringInGermany();
            bool stringContains = GermanCurrency.Contains("?");
            Assert.IsTrue(stringContains);
        }
    }
}