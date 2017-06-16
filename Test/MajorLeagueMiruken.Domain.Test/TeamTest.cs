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
