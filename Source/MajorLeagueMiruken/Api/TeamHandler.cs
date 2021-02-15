namespace MajorLeagueMiruken.Api
{
    using System.Collections.Generic;
    using System.Threading;
    using Miruken.Callback;

    public class TeamHandler
    {
        private int _counter;
        private readonly Dictionary<int, TeamData> _teams = new ();
        
        [Handles]
        public TeamResult Create(CreateTeam create, IHandler composer)
        {
            var team = create.Team with
            {
                Id = Interlocked.Increment(ref _counter)
            };
            _teams.Add(team.Id ?? 0, team);

            return new TeamResult(new TeamData(team.Id ?? 0));
        }
    }
}