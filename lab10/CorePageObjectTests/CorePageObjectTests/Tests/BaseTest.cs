using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace CorePageObjectTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            _chromeDriver = new FirefoxDriver();
            _chromeDriver.Navigate().GoToUrl("https://www.boho.life/");
            var options = new FirefoxOptions();
            options.AddArgument("no-sandbox");
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            //_chromeDriver.Quit();
        }

    }
}
