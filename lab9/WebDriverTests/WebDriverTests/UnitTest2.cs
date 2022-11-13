using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverTests
{
    public class Tests2
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://www.boho.life/");
        }

        [Test]
        public void CheckCampersByLocation()
        {
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _chromeDriver.FindElement(By.XPath("//a[@class='sqs-popup-overlay-close']")).Click();
            _chromeDriver.FindElement(By.LinkText("book a trip")).Click();

            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IJavaScriptExecutor js = _chromeDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _chromeDriver.FindElements(By.XPath("//label[@class='form-label']"))[2].Click();

            List<IWebElement> list = _chromeDriver.FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']")).Where(x => x.Text != "TEMPE").ToList();
            Assert.IsTrue(list.Count == 0);
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}