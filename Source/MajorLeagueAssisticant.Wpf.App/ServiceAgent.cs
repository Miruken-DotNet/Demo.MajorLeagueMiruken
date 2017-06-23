using MajorLeagueMiruken.Domain;
using System.Threading.Tasks;

namespace MajorLeagueAssisticant.Wpf.App
{
    public class ServiceAgent
    {
        private readonly League _league;

        private bool _teamsLoaded = false;

        public ServiceAgent(League league)
        {
            _league = league;
        }

        public async Task LoadTeams()
        {
            if (!_teamsLoaded)
            {
                await Task.Delay(1000);

                LoadTeam(
                    "Dallas", Color.Blue,
                    "Ric", "DeAnda",
                    "Dave", "O'Hara");
                LoadTeam(
                    "Calgary", Color.White,
                    "Brian", "Donaldson",
                    "Wendy", "Brown");
                LoadTeam(
                    "College Station", Color.Maroon,
                    "Mike", "Abney",
                    "Ed", "Grannan");
                LoadTeam(
                    "Columbus", Color.Red,
                    "Jacquie", "Bickel",
                    "Mark", "Kovacevich");
                LoadTeam(
                    "Houston", Color.LightBlue,
                    "Christina", "Liles",
                    "Devlin", "Liles");
                LoadTeam(
                    "Minneapolis", Color.Orange,
                    "Ken", "Howard",
                    "Barb", "Gurtselle");
            }
        }

        private void LoadTeam(
            string name, Color teamColor,
            string managerFirstName, string managerLastName,
            string coachFirstName, string coachLastName)
        {
            var team = _league.CreateTeam();
            team.Name = name;
            team.TeamColor = teamColor;
            var manager = _league.CreatePerson();
            manager.FirstName = managerFirstName;
            manager.LastName = managerLastName;
            team.Manager = manager;
            var coach = _league.CreatePerson();
            coach.FirstName = coachFirstName;
            coach.LastName = coachLastName;
            team.Coach = coach;
        }
    }
}
