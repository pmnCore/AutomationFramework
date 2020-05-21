using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutomationFinal.PageObjects.Source;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.PageObjects
{
    class BbcSportScoresPage : BasePage
    {
        const string currentMonthResultsXPath = "//div[contains(@class, 'sp-c-date-picker-timeline__group')]//a[span[contains(text(), 'RESULTS')]]";
        const string dateXPath = "//div[contains(@class, 'qa-match-block')]/parent::div//div[descendant::h3[contains(text(),'{0}')]]";
        [FindsBy(How = How.XPath, Using = currentMonthResultsXPath)]
        IWebElement CurrentMonthResults { get; set; }
        IWebElement DateScores { get; set; }
        public Score Scoreboard { get; private set; }
        public string League { get; private set; }

        public BbcSportScoresPage(string league)
        {
            League = league;
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(currentMonthResultsXPath)));
            //base
            PageFactory.InitElements(Driver, this);
        }

        public void SelectMatch(string date, string firstTeamName, string secondTeamName)
        {
            ShowCurrentMonthResults();
            SelectDate(date);
            SelectTeams(firstTeamName, secondTeamName);
        }

        public void GoToMatchPage(string date, string firstTeam, string secondTeam)
        {
            SelectMatch(date, firstTeam, secondTeam);
            DateScores.FindElement(By.XPath(".//span[contains(text(), '" + firstTeam + "')]")).Click();
        }

        void ShowCurrentMonthResults()
        {
            if (CurrentMonthResults.Enabled)
                CurrentMonthResults.Click();
        }

        void SelectDate(string date) => DateScores = Wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format(dateXPath, date))));

        void SelectTeams(string firstTeam, string secondTeam) => Scoreboard = new Score(DateScores, firstTeam, secondTeam);

    }
}
