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

            Assert.AreEqual(league.Teams.Count(), 1);
            Assert.AreSame(league.Teams.Single(), team);
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

            Assert.AreSame(team.Manager, manager);
        }

        private League GivenLeague()
        {
            return new League();
        }
    }
}
