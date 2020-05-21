using AutomationFinal.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationFinal.BusinessLogicLayer
{
    [Binding]
    class BusinessLogicLayer
    {
        BasePage CurrentPage { get; set; }
        public BbcSportScoresPage BbcSportScoresPage { get; private set; }
        public BbcSportMatchPage BbcSportMatchPage { get; private set; }

        //public BusinessLogicLayer() { }

        [Given(@"User visits BBC Home Page")]
        public void GoToBbcHomePage()
        {
            new BbcHomePage().GoToHomePage();
            CurrentPage = new BbcHomePage();
        }

        [When(@"User selects League: (.*)")]
        public void SelectLeague(string league)
        {
            if (!(CurrentPage is BbcSportScoresPage) || BbcSportScoresPage.League != league)
            {
                if (!(CurrentPage is BbcSportPage))
                    GoFromHomePageToSportPage();
                new BbcHomePage().GoToSportCategory();
                new BbcSportPage().OpenLeagueMatches(league);
                CurrentPage = new BbcSportScoresPage(league);
            }
        }

        [When(@"User selects a Match by (.*), (.*), (.*), (.*)")]
        public void SelectMatch(string league, string matchDate, string firstTeamName, string secondTeamName)
        {
            SelectLeague(league);
            BbcSportScoresPage.SelectMatch(matchDate, firstTeamName, secondTeamName);
        }

        [When(@"User opens a Page of the Match: (.*), (.*), (.*), (.*)")]
        public void OpenMatch(string league, string matchDate, string firstTeamName, string secondTeamName)
        {
            SelectMatch(league, matchDate, firstTeamName, secondTeamName);
            BbcSportScoresPage.GoToMatchPage(matchDate, firstTeamName, secondTeamName);
            BbcSportMatchPage = new BbcSportMatchPage();
            CurrentPage = BbcSportMatchPage;
        }

        [AfterScenario]
        [Scope(Tag = "MatchPage")]
        public void BackToCurrentMonthResults()
        {
            if (!(CurrentPage is BbcSportScoresPage))
            {
                if (CurrentPage is BbcSportMatchPage)
                    BbcSportMatchPage.GoBackToScoresPage();
                else
                    throw new InvalidOperationException();
            }
        }

        void GoFromHomePageToSportPage()
        {
            new BbcHomePage().GoToSportCategory();
            CurrentPage = new BbcSportPage();
        }

        [Then(@"Match score in Score Table should be (.*) - (.*)")]
        public void ThenMatchScoreInScoreTableShouldBe_(int firstTeamExpectedScore, int secondTeamExpectedScore) => MatchAssert(firstTeamExpectedScore, secondTeamExpectedScore);

        [Then(@"Match score in Match Page should be the same as from Score Table")]
        public void ThenMatchScoreInMatchPageShouldBeTheSameAsFromScoreTable() => MatchAssert(Convert.ToInt32(BbcSportMatchPage.FirstTeamScore.Text), Convert.ToInt32(BbcSportMatchPage.SecondTeamScore.Text));

        private void MatchAssert(int firstTeamExpectedScore, int secondTeamExpectedScore)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(firstTeamExpectedScore, BbcSportScoresPage.Scoreboard.FirstTeamActualScore,
                            $"Mismatch between scores:" +
                            $"\n'{firstTeamExpectedScore}'" +
                            $"\nand actual score:" +
                            $"\n{BbcSportScoresPage.Scoreboard.FirstTeamActualScore}");
                Assert.AreEqual(secondTeamExpectedScore, BbcSportScoresPage.Scoreboard.SecondTeamActualScore,
                            $"Mismatch between scores:" +
                            $"\n'{secondTeamExpectedScore}'" +
                            $"\nand actual score:" +
                            $"\n{BbcSportScoresPage.Scoreboard.SecondTeamActualScore}");

            });
        }
    }
}