using MajorLeagueMiruken.Domain;

namespace MajorLeagueAssisticant.Wpf.App.Teams
{
    public class TeamHeaderViewModel
    {
        private readonly Team _team;

        public TeamHeaderViewModel(Team team)
        {
            _team = team;
        }

        public string Name => _team.Name;
        public Color TeamColor => _team.TeamColor;
        public string Manager => _team.Manager?.FullName;
        public string Coach => _team.Coach?.FullName;
    }
}
