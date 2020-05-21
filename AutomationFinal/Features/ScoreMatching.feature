Feature: CheckGamesMatching
	As a site visitor
	I want to see correct match scores at match results page

Background:
	Given User visits BBC Home Page

@ScoreTable
Scenario Outline: Check score in score table
	When User selects a Match by <League>, <MatchDate>, <FirstTeamName>, <SecondTeamName>
	Then Match score in Score Table should be <ExpectedFirstTeamScore> - <ExpectedSecondTeamScore>
Examples: 
| League        | MatchDate     | FirstTeamName			| SecondTeamName| ExpectedFirstTeamScore| ExpectedSecondTeamScore|
| Scottish Prem | Wednesday 5th | Aberdeen				| St Johnstone	| 0						| 1						 |
| Scottish Prem	| Wednesday 5th	| Heart of Midlothian	| Kilmarnock	| 2						| 3						 |
| Scottish Prem | Wednesday 5th | Motherwell			| Celtic		| 0						| 4						 |
| Scottish Prem | Wednesday 5th | Rangers				| Hibernian		| 2						| 1						 |        
| Scottish Prem | Wednesday 5th | Ross County			| Livingston	| 2						| 0						 |


@MatchPage
Scenario Outline: Check scores between score table and match page
	When User opens a Page of the Match: <League>, <MatchDate>, <FirstTeamName>, <SecondTeamName>
	Then Match score in Match Page should be the same as from Score Table
Examples: 
| League        | MatchDate     | FirstTeamName			| SecondTeamName|
| Scottish Prem | Wednesday 5th | Aberdeen				| St Johnstone	|
| Scottish Prem	| Wednesday 5th	| Heart of Midlothian	| Kilmarnock	|
| Scottish Prem | Wednesday 5th | Motherwell			| Celtic		|
| Scottish Prem | Wednesday 5th | Rangers				| Hibernian		|
| Scottish Prem | Wednesday 5th | Ross County			| Livingston	|

