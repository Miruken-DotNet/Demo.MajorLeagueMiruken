using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MajorLeagueMiruken.Domain.Test
{
    [TestClass]
    public class LeagueTest
    {
        [TestMethod]
        public void CanCreateATeam()
        {
            var league = GivenLeague();

            var team = league.CreateTeam();

            Assert.IsNotNull(team);
        }

        [TestMethod]
        public void CanListTeams()
        {
            var league = GivenLeague();
            var team = league.CreateTeam();

            Assert.AreEqual(1, league.Teams.Count());
            Assert.AreSame(team, league.Teams.Single());
        }

        [TestMethod]
        public void CanAddAPerson()
        {
            var league = GivenLeague();

            var person = league.CreatePerson();

            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void CanSetAManager()
        {
            var league = GivenLeague();
            var team = league.CreateTeam();
            var manager = league.CreatePerson();

            team.Manager = manager;

            Assert.AreSame(manager, team.Manager);
        }

        private League GivenLeague()
        {
            return new League();
        }
    }
}
