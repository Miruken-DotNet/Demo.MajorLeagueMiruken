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

        private League GivenLeague()
        {
            return new League();
        }
    }
}
