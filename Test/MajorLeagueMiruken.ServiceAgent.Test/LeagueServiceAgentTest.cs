using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajorLeagueMiruken.Domain;
using System.Linq;
using Miruken.Concurrency;
using System.Threading.Tasks;
using Miruken.Castle;
using Castle.Windsor.Installer;
using Miruken.Context;
using Miruken.Mvc;
using Castle.MicroKernel.Registration;
using Miruken.Mvc.Castle;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    [TestClass]
    public class LeagueServiceAgentTest
    {
        [TestMethod]
        public void InitiallyHasNoTeams()
        {
            WithServiceAgent(serviceAgent =>
            {
                var league = serviceAgent.League;

                Assert.AreEqual(0, league.Teams.Count());
            });
        }

        [TestMethod]
        public async Task CanLoadATeam()
        {
            await WithServiceAgent(async serviceAgent =>
            {
                var league = serviceAgent.League;

                await serviceAgent.LoadTeams();

                Assert.AreEqual(1, league.Teams.Count());
            });
        }

        private void WithServiceAgent(Action<ILeagueServiceAgent> action)
        {
            var appContext = GivenAppContext();
            var serviceAgent = Miruken.Protocol.P<ILeagueServiceAgent>(appContext);
            action(serviceAgent);
        }

        private Task WithServiceAgent(Func<ILeagueServiceAgent, Task> asyncAction)
        {
            var appContext = GivenAppContext();
            var serviceAgent = Miruken.Protocol.P<ILeagueServiceAgent>(appContext);
            return asyncAction(serviceAgent);
        }

        private static Context GivenAppContext()
        {
            var handler = new WindsorHandler(container =>
            {
                container.Install(
                    FromAssembly.Containing<ILeagueServiceAgent>(),
                    new MvcInstaller(Classes.FromThisAssembly()),
                    new ConfigurationFactoryInstaller(Types.FromThisAssembly()),
                    new ResolvingInstaller(
                        Classes.FromThisAssembly(),
                        Classes.FromAssemblyContaining<ILeagueServiceAgent>())
                );
            });

            var appContext = new Context();
            appContext.AddHandlers(handler);
            return appContext;
        }
    }
}
