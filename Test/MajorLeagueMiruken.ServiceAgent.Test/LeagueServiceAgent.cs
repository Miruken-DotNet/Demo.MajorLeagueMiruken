using MajorLeagueMiruken.Domain;
using MajorLeagueMiruken.Mvc.Features.Team;
using Miruken.Concurrency;
using System;
using System.Threading.Tasks;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    public class LeagueServiceAgent
    {
        public League League { get; } = new League();

        public Promise LoadTeams()
        {
            return P<ITeam>(IO).Teams().Then((teams, s) =>
            {
                Teams = teams;
            });
        }
    }
}
