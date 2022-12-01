using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CorePageObjectTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver _chromeDriver;
        [SetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://www.boho.life/");
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }

    }
}
