using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CorePageObjectTests.PageObjects
{
    public class MainPageObject : BasePageObject
    {
        private const string BASE_URL = "https://www.boho.life/";

        public MainPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _popUpWindow => driver
            .FindElement(By.XPath("//a[@class='sqs-popup-overlay-close']"));
        private IWebElement _btnBookATrip => driver.FindElement(By.LinkText("book a trip"));
        private IWebElement _btnBuy => driver.FindElement(By.XPath("/html/body/div[4]/header/div/div[4]/div/nav/div[2]/div[1]"));
        private IWebElement _btnFinancing => driver.FindElement(By.XPath("/html/body/div[4]/header/div/div[4]/div/nav/div[2]/div[2]/div[4]/a"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public void ClickOnBookATrip()
        {
            _btnBookATrip.Click();
        }
        public void ClickOnFinancing()
        {
            Actions action = new Actions(driver);
            Thread.Sleep(600);
            action.MoveToElement(_btnBuy);
            Thread.Sleep(600);
            action.MoveToElement(_btnFinancing);
            Thread.Sleep(600);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", _btnFinancing);

        }
        public void ClickOnBuy()
        {
            _btnBuy.Click();
        }
        public MainPageObject ClosePopUpWindow()
        {
            _popUpWindow.Click();
            return this;
        }
    }
}
