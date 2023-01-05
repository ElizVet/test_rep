using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class BookTripPageObject : BasePageObject
    {
        public BookTripPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _nestedIframe => _webDriver
            .FindElement(By.XPath("//*[@id='iFrameResizer0']"));

        private IWebElement _checkboxTempeLocation => _webDriver.
            FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[2]/div[1]/div[2]/ul/li[3]/label/input"));

        private List<IWebElement> _listOfCampersWithLocationTempe => _webDriver
            .FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']"))
            .Where(x => x.Text != "TEMPE")
            .ToList();

        private List<IWebElement> _listOfAllCampers => _webDriver
            .FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']"))
            .ToList();

        private IWebElement _languageSelection;

        private IWebElement _GermanyLanguage;

        private string _stringInGermany;

        public void GoToTheNestedIframe() => _webDriver.SwitchTo().Frame(_nestedIframe);
        public void SetActiveTempeLocation() => _checkboxTempeLocation.Click();
        public List<IWebElement> GetListCampersWithLocationTempe() => _listOfCampersWithLocationTempe;
        public List<IWebElement> GetListAllCampers() => _listOfAllCampers;
        public void OpenTheListOfLanguages()
        {
            _languageSelection = _webDriver.FindElement(By.XPath("//div[@class='language-selection']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].click();", _languageSelection);
        }
        public void ChooseGermanyLanguage()
        {
            _GermanyLanguage = _webDriver
            .FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[1]/div/div/div/div/ul/li[7]/a"));
            _GermanyLanguage.Click();
        }
        public string GetStringInGermany()
        {
            _stringInGermany = _webDriver
                .FindElement(By.XPath("//*[@id='ember429']"))
                .Text;
            return _stringInGermany;
        }

    }
}
