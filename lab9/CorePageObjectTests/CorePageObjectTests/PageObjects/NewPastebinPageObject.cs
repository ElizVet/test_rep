using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace CorePageObjectTests.PageObjects
{
    class NewPastebinPageObject : BasePageObject
    {
        public NewPastebinPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _syntaxHighlighting = _webDriver
            .FindElement(By.XPath("//a[text()='Bash']"));

        private List<IWebElement> _bashStrings => _webDriver
            .FindElements(By.XPath("//li[@class='li1']"))
            .ToList(); 

        public string GetSyntaxHighlighting() => _syntaxHighlighting.Text;
        public List<IWebElement> GetBashCode() => _bashStrings;
    }
}
