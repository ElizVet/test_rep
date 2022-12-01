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

        private IWebElement _btnSelectExpiration => _webDriver
            .FindElement(By.Id("select2-postform-expiration-container"));
        private IWebElement _btn10Minutes => _webDriver
            .FindElement(By.XPath("//li[text()='10 Minutes']"));
        private IWebElement _btnSelectSintaxHighlighting => _webDriver
            .FindElement(By.Id("select2-postform-format-container"));
        private IWebElement _btnBash => _webDriver
            .FindElement(By.XPath("//li[text()='Bash']"));
        private IWebElement _btnCreateNewPaste => _webDriver
            .FindElement(By.XPath("//button[@class='btn -big']"));
        private IWebElement _inputTextArea => _webDriver
            .FindElement(By.Id("postform-text"));
        private IWebElement _inputTitle => _webDriver
            .FindElement(By.Id("postform-name"));


        public void ClickSelectExpiration() => _btnSelectExpiration.Click();
        public void ClickBtn10Minutes() => _btn10Minutes.Click();
        public void ClickSelectSintaxHighlighting() => _btnSelectSintaxHighlighting.Click();
        public void ClickBtnBash() => _btnBash.Click();
        public void ClickBtnCreateNewPaste() => _btnCreateNewPaste.Click();
        public void SendTextToInputTextArea(string text) => _inputTextArea.SendKeys(text);
        public void SendTextToTitle(string text) => _inputTitle.SendKeys(text);
    }
}
