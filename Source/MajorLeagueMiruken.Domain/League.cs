using Assisticant.Collections;
using System.Collections.Generic;

namespace MajorLeagueMiruken.Domain
{
    public class League
    {
        private ObservableList<Team> _teams = new ObservableList<Team>();

        public IEnumerable<Team> Teams => _teams;

        public Team CreateTeam()
        {
            var team = new Team();
            _teams.Add(team);
            return team;
        }
    }
}
