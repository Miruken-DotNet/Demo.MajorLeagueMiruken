using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajorLeagueMiruken.Domain;
using System.Linq;
using Miruken.Concurrency;
using System.Threading.Tasks;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    [TestClass]
    public class LeagueServiceAgentTest
    {
        [TestMethod]
        public void InitiallyHasNoTeams()
        {
            var serviceAgent = GivenServiceAgent();
            var league = serviceAgent.League;

            Assert.AreEqual(0, league.Teams.Count());
        }

        [TestMethod]
        public async Task CanLoadATeam()
        {
            var serviceAgent = GivenServiceAgent();
            var league = serviceAgent.League;

            await serviceAgent.LoadTeams();

            Assert.AreEqual(1, league.Teams.Count());
        }

        private static LeagueServiceAgent GivenServiceAgent()
        {
            return new LeagueServiceAgent();
        }
    }
}
