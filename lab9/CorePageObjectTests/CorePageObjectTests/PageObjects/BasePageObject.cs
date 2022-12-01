using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class BasePageObject
    {
        protected static IWebDriver _webDriver;

        public BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
