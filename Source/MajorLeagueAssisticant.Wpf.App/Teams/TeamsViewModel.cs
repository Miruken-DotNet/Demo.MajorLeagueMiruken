using Assisticant.Fields;
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

        private Observable<bool> _loading = new Observable<bool>(false);
        private Observable<string> _error = new Observable<string>(null);

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

        public async void Load()
        {
            try
            {
                _error.Value = null;
                _loading.Value = true;

                await _serviceAgent.LoadTeams();
            }
            catch (Exception x)
            {
                _error.Value = x.Message;
            }
            finally
            {
                _loading.Value = false;
            }
        }

        public bool Loading => _loading;
        public string Error => _error;
        public IEnumerable<TeamHeaderViewModel> Teams => _league.Teams.Select(_createTeamHeaderViewModel);
    }
}
