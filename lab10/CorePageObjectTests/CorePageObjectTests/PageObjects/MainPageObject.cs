using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class MainPageObject : BasePageObject
    {
        public MainPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _btnBookATrip => _webDriver.FindElement(By.LinkText("book a trip"));

        public void ClickOnBookATrip() => _btnBookATrip.Click();
    }
}
