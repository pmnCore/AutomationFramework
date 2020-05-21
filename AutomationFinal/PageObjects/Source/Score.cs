using System;
using OpenQA.Selenium;

namespace AutomationFinal.PageObjects.Source
{
    public class Score
    {
        public int FirstTeamActualScore { get; }
        public int SecondTeamActualScore { get; }

        public Score(IWebElement dateBlock, string firstTeam, string secondTeam)
        {
            FirstTeamActualScore = Convert.ToInt32(GetScore(dateBlock, firstTeam).Text);
            SecondTeamActualScore = Convert.ToInt32(GetScore(dateBlock, secondTeam).Text);
        }

        IWebElement GetScore(IWebElement element, string team) => element.FindElement(By.XPath(".//span[descendant::span[contains(text(), '" + team + "')]]/descendant::span[contains(@class, 'sp-c-fixture__number')]"));
    }
}