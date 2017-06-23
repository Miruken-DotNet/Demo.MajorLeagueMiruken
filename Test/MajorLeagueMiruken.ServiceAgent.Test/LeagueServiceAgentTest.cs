using MajorLeagueMiruken.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miruken.Callback;
using Miruken.Context;
using System.Linq;
using System.Threading.Tasks;
using static Miruken.Protocol;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    [TestClass]
    public class LeagueServiceAgentTest
    {
        [TestMethod]
        public void InitiallyHasNoTeams()
        {
            var context = GivenAppContext();
            var league = context.Resolve<League>();

            Assert.AreEqual(0, league.Teams.Count());
        }

        [TestMethod]
        public async Task CanLoadATeam()
        {
            var context = GivenAppContext();
            var handler = context.Resolve<LeagueServiceAgent>();

            await P<ILeagueServiceAgent>(handler).LoadTeams()
                .Then((r,s) =>
                {
                    var league = context.Resolve<League>();
                    Assert.AreEqual(6, league.Teams.Count());
                });
        }

        private static Context GivenAppContext()
        {
            var appContext = new Context();
            appContext.Store(new League());
            appContext.AddHandlers(new LeagueServiceAgent());
            return appContext;
        }
    }
}
