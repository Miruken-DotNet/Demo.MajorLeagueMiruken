using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MajorLeagueMiruken.Domain.Test
{
    [TestClass]
    public class LeagueTest
    {
        [TestMethod]
        public void CanCreateATeam()
        {
            League league = GivenLeague();

            Team team = league.CreateTeam();

            Assert.IsNotNull(team);
        }

        private League GivenLeague()
        {
            throw new NotImplementedException();
        }
    }
}
