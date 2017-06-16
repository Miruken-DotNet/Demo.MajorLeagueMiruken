using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MajorLeagueMiruken.Domain.Test
{
    [TestClass]
    public class TeamTest
    {
        private League _league;

        [TestInitialize]
        public void InitializeLeague()
        {
            _league = new League();
        }

        [TestMethod]
        public void CanAddPlayer()
        {
            var team = GivenTeam();
            var person = GivenPerson();

            var player = team.AddPlayer(person);

            Assert.IsNotNull(player);
            Assert.AreSame(person, player.Person);
            Assert.AreSame(team, player.Team);
        }

        [TestMethod]
        public void CanListRoster()
        {
            var team = GivenTeam();
            var person = GivenPerson();
            var player = team.AddPlayer(person);

            Assert.AreEqual(1, team.Roster.Count());
            Assert.AreSame(player, team.Roster.Single());
        }

        [TestMethod]
        public void APersonCanOnlyPlayForOneTeam()
        {
            var team1 = GivenTeam();
            var team2 = GivenTeam();
            var person = GivenPerson();

            var player1 = team1.AddPlayer(person);
            var player2 = team2.AddPlayer(person);

            Assert.AreEqual(0, team1.Roster.Count());
            Assert.AreEqual(1, team2.Roster.Count());
            Assert.AreSame(player2, team2.Roster.Single());
        }

        [TestMethod]
        public void AddingAPlayerTwiceHasNoEffect()
        {
            var team = GivenTeam();
            var person = GivenPerson();

            var player1 = team.AddPlayer(person);
            var player2 = team.AddPlayer(person);

            Assert.AreEqual(1, team.Roster.Count());
            Assert.AreSame(player2, team.Roster.Single());
        }

        private Team GivenTeam()
        {
            return _league.CreateTeam();
        }

        private Person GivenPerson()
        {
            return _league.CreatePerson();
        }
    }
}
