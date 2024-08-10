using System;
using NUnit.Framework;

namespace Championship.Tests
{
    public class Tests
    {
        private League league;
        private Team team;
        private string teamName;
        [SetUp]
        public void Setup()
        {
            teamName = Random.Shared.Next().ToString();
            team = new Team(teamName);
            league = new League();
        }

        [Test]
        public void ConstructorCreateCorrectly()
        {
            League league = new League();

            Assert.IsNotNull(league.Teams.Count);
            Assert.That(league.Capacity , Is.EqualTo(10));
        }

        [Test]
        public void AddTeamWorkCorrectly()
        {
            string teamName = Random.Shared.Next().ToString();
            Team team = new Team(teamName);
            league.AddTeam(team);
            Assert.That(league.Teams.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddTeamThrowIfTeamExist()
        {
            string teamName = Random.Shared.Next().ToString();
            Team team = new Team(teamName);
            league.AddTeam(team);
            Assert.Throws<InvalidOperationException>(() =>league.AddTeam(team));
        }

        [Test]
        public void AddTeamThrowIfCapacityIsReach()
        {
            string teamName = Random.Shared.Next().ToString();
            Team team = new Team(teamName);
            Team team1 = new Team(Random.Shared.Next().ToString());
            Team team2 = new Team(Random.Shared.Next().ToString());
            Team team3 = new Team(Random.Shared.Next().ToString());
            Team team4 = new Team(Random.Shared.Next().ToString());
            Team team5 = new Team(Random.Shared.Next().ToString());
            Team team6 = new Team(Random.Shared.Next().ToString());
            Team team7 = new Team(Random.Shared.Next().ToString());
            Team team8 = new Team(Random.Shared.Next().ToString());
            Team team9 = new Team(Random.Shared.Next().ToString());
            Team team10 = new Team(Random.Shared.Next().ToString());

            league.AddTeam(team1);
            league.AddTeam(team2);
            league.AddTeam(team3);
            league.AddTeam(team4);
            league.AddTeam(team5);
            league.AddTeam(team6);
            league.AddTeam(team7);
            league.AddTeam(team8);
            league.AddTeam(team9);
            league.AddTeam(team10);
            Assert.Throws<InvalidOperationException>(() => league.AddTeam(team));
        }

        [Test]
        public void RemoveReturnTrueIfRemoved()
        {
            league.AddTeam(team);
            Assert.IsTrue(league.RemoveTeam(teamName));
        }

        [Test]
        public void RemoveRemovingRightTeam()
        {
            Team team1 = new Team(Random.Shared.Next().ToString());
            Team team2 = new Team(Random.Shared.Next().ToString());
            Team team3 = new Team(Random.Shared.Next().ToString());
            league.AddTeam(team1);
            league.AddTeam(team2);
            league.AddTeam(team3);
            league.RemoveTeam(team2.Name);
            Assert.Throws<InvalidOperationException>(() => league.GetTeamInfo(team2.Name));
            Assert.That(league.Teams.Count , Is.EqualTo(2));

        }

        [Test]
        public void RemoveReturnFalseIfCantRemove()
        {
            league.AddTeam(team);
            Assert.IsFalse(league.RemoveTeam("g"));
        }

        [Test]
        public void PlayMatchThrowIfOneTeamIsNullOrTwoTeamsAreNull()
        {
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(teamName, null, 4, 5));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(null, teamName, 4, 5));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(null, null, 4, 5));
        }

        [Test]
        public void PlayMatchAddToTeamDrawIfDraw()
        {
            Team team1 = new Team(Random.Shared.Next().ToString());
            Team team2 = new Team(Random.Shared.Next().ToString());
            league.AddTeam(team1);
            league.AddTeam(team2);
            int score = Random.Shared.Next();
            league.PlayMatch(team1.Name,team2.Name,score,score);
            Assert.That(team2.Draws, Is.EqualTo(1));
            Assert.That(team1.Draws, Is.EqualTo(1));
        }
        [Test]
        public void PlayMatchAddToWinnerAndLoser()
        {
            Team team1 = new Team(Random.Shared.Next().ToString());
            Team team2 = new Team(Random.Shared.Next().ToString());
            league.AddTeam(team1);
            league.AddTeam(team2);
            int score = Random.Shared.Next();
            league.PlayMatch(team1.Name, team2.Name, 2, 1);
            Assert.That(team2.Loses, Is.EqualTo(1));
            Assert.That(team1.Wins, Is.EqualTo(1));
            league.PlayMatch(team1.Name, team2.Name, 1, 2);
            Assert.That(team1.Loses, Is.EqualTo(1));
            Assert.That(team2.Wins, Is.EqualTo(1));
        }

        [Test]
        public void GetTeamInfoThrowIfTeamDontExists()
        {
            Assert.Throws<InvalidOperationException>(() =>league.GetTeamInfo("a"));
        }

        [Test]
        public void GetTeamInfoWorkCorrectly()
        {
            Team team1 = new Team("abs");
            league.AddTeam(team1);
            Assert.That(team1.ToString(),Is.EqualTo(league.GetTeamInfo("abs")));
        }

 
   
    }
}