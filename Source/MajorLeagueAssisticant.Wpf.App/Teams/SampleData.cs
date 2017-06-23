using MajorLeagueMiruken.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorLeagueAssisticant.Wpf.App.Teams
{
    class SampleData
    {
        public TeamsViewModel Teams { get; } = GenerateTeams();

        private static TeamsViewModel GenerateTeams()
        {
            var league = new League();
            var serviceAgent = new ServiceAgent(league);
            var navigationModel = new NavigationModel();

            var dallas = league.CreateTeam();
            dallas.Name = "Dallas";
            dallas.TeamColor = Color.Blue;
            var ric = league.CreatePerson();
            ric.FirstName = "Ric";
            ric.LastName = "DeAnda";
            dallas.Manager = ric;
            var dave = league.CreatePerson();
            dave.FirstName = "Dave";
            dave.LastName = "O'Hara";
            dallas.Coach = dave;

            var viewModel = new TeamsViewModel(league, serviceAgent, navigationModel, t => new TeamHeaderViewModel(t));

            return viewModel;
        }
    }
}
