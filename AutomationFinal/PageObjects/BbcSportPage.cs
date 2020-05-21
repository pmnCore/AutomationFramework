using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.PageObjects
{
    class BbcSportPage : BasePage
    {
        const string scoresMoreSectionXPath = "//div[contains(@class, 'gs-u-display-none gs-u-display-block@l')]//div[contains(@class, 'sp-c-cluster football-scores-fixtures-wrapper')]//div//span[contains(text(),'More')]";
        const string viewAllMatchesXPath = "//div[contains(@class, 'gs-u-display-none gs-u-display-block@l')]//span[contains(text(), 'View all')]";
        const string leagueXpath = "//div[contains(@class, 'sp-c-filter__block sp-c-filter__block--expanded')]//button[contains(@class, 'sp-c-filter__list-link')][contains(text(),'{0}')]";
        [FindsBy(How = How.XPath, Using = scoresMoreSectionXPath)]
        IWebElement ScoresMoreSection { get; set; }

        public BbcSportPage()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(viewAllMatchesXPath)));
            PageFactory.InitElements(Driver, this);
        }

        public void OpenLeagueMatches(string league)
        {
            OpenAllLeagues();
            SelectLeague(league);
            GoToAllLeagueMatches();
        }

        void OpenAllLeagues() => ScoresMoreSection.Click();

        void SelectLeague(string league) => Wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format(leagueXpath, league)))).Click();

        //Note: when select/change league, linq disappears for a moment and autotest cant reach this linq, so we dont need to initialize 'View all matches' in PageFactory
        void GoToAllLeagueMatches() => Wait.Until(ExpectedConditions.ElementExists(By.XPath(viewAllMatchesXPath))).Click();
    }
}
