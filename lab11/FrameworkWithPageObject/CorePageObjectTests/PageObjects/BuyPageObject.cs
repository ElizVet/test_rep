using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CorePageObjectTests.PageObjects
{
    class BuyPageObject : BasePageObject
    {
        public BuyPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement _img;
        private IWebElement _nextImageButton => driver.FindElement(By.XPath("//a[@class='next']"));

        public BuyPageObject ClickNextImageButton()
        {
            Thread.Sleep(600);

            _nextImageButton.Click();
            return this;
        }

        public BuyPageObject MoveNextImageButton() 
        {
            Actions action = new Actions(driver);
            Thread.Sleep(600);
            action.MoveToElement(_nextImageButton);

            Thread.Sleep(600);

            _nextImageButton.Click();
            return this;
        }

        public bool CheckHiddenImage() 
        {
            Thread.Sleep(600);

            _img = driver.FindElement(By.XPath("/html/body/div[5]/main/div/div[4]/div[3]/div/div/div/div/div[3]/div/div[1]/div[1]/div[2]"));

            return _img.Displayed;
        }
    }
}
