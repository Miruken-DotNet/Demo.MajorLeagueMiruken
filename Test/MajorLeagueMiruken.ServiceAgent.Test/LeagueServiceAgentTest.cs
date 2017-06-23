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
            var league = context.Resolve<ILeague>();

            Assert.AreEqual(0, league.Teams.Count());
        }

        [TestMethod]
        public async Task CanLoadATeam()
        {
            var context = GivenAppContext();

            await P<ILeagueServiceAgent>(context).LoadTeams()
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
            var serviceAgent = new LeagueServiceAgent();
            serviceAgent.Context = appContext;
            appContext.AddHandlers(serviceAgent);
            return appContext;
        }
    }
}
