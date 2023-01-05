using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CorePageObjectTests.PageObjects
{
    class FinancingPageObject : BasePageObject
    {
        public FinancingPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _projectCost => driver
            .FindElement(By.XPath("//*[@id='amount']"));
        private IWebElement _creditScore => driver
            .FindElement(By.XPath("//*[@id='credit']"));
        private IWebElement _creditScorePoor => driver
            .FindElement(By.XPath("/html/body/div/div[3]/div[1]/select/option[4]"));
        private IWebElement _getFinancingOptions => driver
            .FindElement(By.XPath("/html/body/div/div[3]/div[2]/a"));
        private IWebElement _nestedIframe => driver
            .FindElement(By.XPath("//iframe[@id='hearth-widget_calculator_v1']"));
        private string _estimated => driver
            .FindElement(By.XPath("//*[@id='monthly']")).Text;


        public FinancingPageObject GoToTheNestedIframe()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//iframe[@id='hearth-widget_calculator_v1']")));

            driver.SwitchTo().Frame(_nestedIframe);

            return this;
        }

        public FinancingPageObject ChooseProjectCostField()
        {
            Thread.Sleep(600);
            _projectCost.Click();
            return this;
        }

        public FinancingPageObject InputProjectCostField()
        {
            Thread.Sleep(600);
            _projectCost.SendKeys("1000");
            return this;
        }

        public FinancingPageObject ChooseCreditScore()
        {
            Thread.Sleep(600);
            _creditScore.Click();
            return this;
        }

        public FinancingPageObject ChooseCreditScorePoor()
        {
            Thread.Sleep(600);
            _creditScorePoor.Click();
            return this;
        }

        public string GetResultEstimated()
        {
            Thread.Sleep(600);
            return _estimated;
        }
    }
}
