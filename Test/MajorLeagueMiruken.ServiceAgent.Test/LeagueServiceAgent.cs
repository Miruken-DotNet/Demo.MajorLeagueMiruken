using MajorLeagueMiruken.Domain;
using MajorLeagueMiruken.Mvc.Features.Team;
using Miruken.Concurrency;
using Miruken.Mvc;
using System;
using System.Threading.Tasks;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    public class LeagueServiceAgent : Controller
    {
        public League League { get; } = new League();

        public Promise LoadTeams()
        {
            return P<ITeam>(IO).Teams().Then((teamMementos, s) =>
            {
                foreach (var teamMemento in teamMementos)
                {
                    var team = League.CreateTeam();
                }
            });
        }
    }
}
