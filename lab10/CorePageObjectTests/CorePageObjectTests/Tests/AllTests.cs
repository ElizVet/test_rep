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
            // —оздание экземпл€ров страниц, передача внутрь переменной, к-€ определ€етс€ в BaseTest
            MainPageObject mainPage = new MainPageObject(_chromeDriver);
            BookTripPageObject bookTripPage = new BookTripPageObject(_chromeDriver);

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

            mainPage.ClickOnBookATrip();

            bookTripPage.GoToTheNestedIframe();
            bookTripPage.OpenTheListOfLanguages();
            bookTripPage.ChooseGermanyLanguage();

            string GermanCurrency = bookTripPage.GetStringInGermany();
            bool stringContains = GermanCurrency.Contains("И");
            Assert.IsTrue(stringContains);
        }

    }
}