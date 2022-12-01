using CorePageObjectTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.Tests
{
    public class AllTests : BaseTest
    {
        [Test]
        public void ICanWin()
        {
            MainPageObject startPage = new MainPageObject(_chromeDriver);

            startPage.SendTextToInputTextArea("Hello from WebDriver");
            startPage.ClickSelectExpiration();
            startPage.ClickBtn10Minutes();
            startPage.SendTextToTitle("helloweb");

            startPage.ClickBtnCreateNewPaste();
        }


        [Test]
        public void BringItOn()
        {
            MainPageObject startPage = new MainPageObject(_chromeDriver);

            string code = "git config --global user.name  \"New Sheriff in Town\"" +
                "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")" +
                "\ngit push origin master --force";
            startPage.SendTextToInputTextArea(code);

            startPage.ClickSelectSintaxHighlighting();
            startPage.ClickBtnBash();

            startPage.ClickSelectExpiration();
            startPage.ClickBtn10Minutes();

            startPage.SendTextToTitle("how to gain dominance among developers");

            startPage.ClickBtnCreateNewPaste();

            NewPastebinPageObject newPastebinPage = new NewPastebinPageObject(_chromeDriver);

            string syntaxHighlighting = newPastebinPage.GetSyntaxHighlighting();

            Assert.AreEqual("how to gain dominance among developers - Pastebin.com", _chromeDriver.Title);
            Assert.AreEqual("Bash", syntaxHighlighting);

            string expectedStr = "";
            foreach (var item in newPastebinPage.GetBashCode())
            {
                expectedStr += item.Text + "\n";
            }
            StringAssert.Contains(expectedStr, code + "\n");
        }
    }
}