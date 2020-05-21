using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.PageObjects
{
        class BbcSportMatchPage : BasePage
        {
            const string firstTeamXPath = "//span[contains(@class, 'fixture__number--home')][not(contains(@class, 'sp-c'))]";
            const string secondTeamXPath = "//span[contains(@class, 'fixture__number--away')][not(contains(@class, 'sp-c'))]";
            [FindsBy(How = How.XPath, Using = firstTeamXPath)]
            public IWebElement FirstTeamScore { get; private set; }
            [FindsBy(How = How.XPath, Using = secondTeamXPath)]
            public IWebElement SecondTeamScore { get; private set; }
            public BbcSportMatchPage()
            {
                Wait.Until(ExpectedConditions.ElementExists(By.XPath(secondTeamXPath)));
                PageFactory.InitElements(Driver, this);
            }

            public void GoBackToScoresPage() => Driver.Navigate().Back();
        }
}
