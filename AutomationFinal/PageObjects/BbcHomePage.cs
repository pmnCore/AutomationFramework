using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.PageObjects
{
    class BbcHomePage : BasePage
    {
        const string url = "https://www.bbc.com";
        const string sportCategoryXpath = "//header[@id='orb-banner']//a[contains(text(),'Sport')]";

        [FindsBy(How = How.XPath, Using = sportCategoryXpath)]
        IWebElement SportCategory { get; set; }

        public BbcHomePage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public void GoToSportCategory()
        {
            if (Driver.Url != url)
                GoToHomePage();
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(sportCategoryXpath)));
            SportCategory.Click();
        }

        public void GoToHomePage() => Driver.Navigate().GoToUrl(url);
    }
}
