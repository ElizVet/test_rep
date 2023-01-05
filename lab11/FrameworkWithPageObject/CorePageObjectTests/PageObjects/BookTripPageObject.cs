using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class BookTripPageObject : BasePageObject
    {
        public BookTripPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _nestedIframe => driver
            .FindElement(By.XPath("//*[@id='iFrameResizer0']"));

        private IWebElement _week => driver
            .FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/div[1]/div[2]/div/button[1]"));

        private IWebElement _checkboxTempeLocation => driver.
            FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[2]/div[1]/div[2]/ul/li[3]/label"));

        private List<IWebElement> _listOfCampersWithLocationTempe => driver
            .FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']"))
            .Where(x => x.Text != "TEMPE")
            .ToList();

        private List<IWebElement> _listOfAllCampers => driver
            .FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']"))
            .ToList();

        private IWebElement _checkMonth => driver
            .FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/div[2]/div/table/thead/tr/td[3]/div/div/div/div[1]/table/tbody/tr[1]/th[1]/div/span"));

        private IWebElement _languageSelection;

        private IWebElement _GermanyLanguage;

        private string _stringInGermany;

        private IWebElement _calendarButton;

        public List<IWebElement> GetListCampersWithLocationTempe() => _listOfCampersWithLocationTempe;
        public List<IWebElement> GetListAllCampers() => _listOfAllCampers;



        public BookTripPageObject GoToTheNestedIframe()
        {
            driver.SwitchTo().Frame(_nestedIframe);
            return this;
        }
        public BookTripPageObject SetActiveTempeLocation()
        {
            Thread.Sleep(600);
            _checkboxTempeLocation.Click();
            return this;
        }
        

        public BookTripPageObject OpenTheListOfLanguages()
        {
            _languageSelection = driver.FindElement(By.XPath("//div[@class='language-selection']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", _languageSelection);
            return this;
        }
        public BookTripPageObject ChooseGermanyLanguage()
        {
            _GermanyLanguage = driver
            .FindElement(By.XPath("//*[text()='Germany']/.."));
            _GermanyLanguage.Click();
            return this;
        }
        public string GetStringInGermany()
        {
            _stringInGermany = driver
                .FindElement(By.XPath("//*[@id='ember5']/div[1]/div/div[2]/div[1]/div[3]/label"))
                .Text;
            return _stringInGermany;
        }
        
        
        public BookTripPageObject OpenCalendar()
        {
            Thread.Sleep(600);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[1]/div/div/div/button[1]")));
            return this;
        }
        public BookTripPageObject SelectAnyCamperInTheCalendar()
        {
            Thread.Sleep(600);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By
                .XPath("/html/body/div[5]/div[1]/div/div[2]/div[2]/div/table/tbody/tr/td[1]/div/div/div/div[1]/div/table/tbody/tr[1]/td[2]/div/div/span[2]/a")));

            return this;
        }
        public BookTripPageObject GetRentedIntervalInTheCalendar()
        {
            driver.FindElement(By
                .XPath("/html/body/div[5]/div[1]/div/div/div[1]/div/div[2]/div[1]/div/div[1]/div/div[2]/div[2]/div[5]/button[3]"))
                .Click();

            driver.FindElement(By
                .XPath("/html/body/div[5]/div[1]/div/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div[2]/div[2]/div[2]/button[3]"))
                .Click();

            return this;
        }
        
        
        public BookTripPageObject ChooseWeek()
        {
            _week.Click();
            return this;
        }
        public string GetStringInMonth()
        {
            Thread.Sleep(600);

            return driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/div[1]/div[3]/h2")).Text;
        }
    }
}
