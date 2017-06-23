using MajorLeagueMiruken.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MajorLeagueAssisticant.Wpf.App.Teams
{
    class TeamsViewModel
    {
        private readonly League _league;
        private readonly ServiceAgent _serviceAgent;
        private readonly NavigationModel _navigationModel;
        private readonly Func<Team, TeamHeaderViewModel> _createTeamHeaderViewModel;

        public TeamsViewModel(
            League league,
            ServiceAgent serviceAgent,
            NavigationModel navigationModel,
            Func<Team, TeamHeaderViewModel> createTeamHeaderViewModel)
        {
            _league = league;
            _serviceAgent = serviceAgent;
            _navigationModel = navigationModel;
            _createTeamHeaderViewModel = createTeamHeaderViewModel;
        }

        public IEnumerable<TeamHeaderViewModel> Teams => _league.Teams.Select(_createTeamHeaderViewModel);
    }
}
