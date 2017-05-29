namespace MajorLeagueMiruken.Console.Features.Team
{
    using Api;
    using Miruken.Concurrency;
    using Mvc.Features.Team;

    public class TeamController : FeatureController
    {
        public Team Team { get; set; }

        public Promise ShowTeam(int id)
        {
            return P<ITeam>().Team(id).Then((team, s) =>
             {
                Team = team;
                Show<TeamView>();
             });
        }

        public Promise GoToEditTeam()
        {
            return Next<EditTeamController>().ShowEditTeam(Team.Id);
        }
    }
}
