using Castle.MicroKernel.Registration;
using MajorLeagueMiruken.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miruken.Callback;
using Miruken.Castle;
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
            return new Context()
                .WithWindsorHandler()
                .WithLeague();
        }
    }

    static class ContextExtensions
    {
        public static Context WithWindsorHandler(this Context appContext)
        {
            var windsorHandler = new WindsorHandler(container =>
            {
                container.Register(Component
                    .For<ILeagueServiceAgent>()
                    .ImplementedBy<LeagueServiceAgent>());
            });
            appContext.AddHandlers(windsorHandler);
            return appContext;
        }

        public static Context WithLeague(this Context appContext)
        {
            appContext.Store(new League());
            return appContext;
        }
    }
}
