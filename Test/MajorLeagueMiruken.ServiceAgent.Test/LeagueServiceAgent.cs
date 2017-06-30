using MajorLeagueMiruken.Domain;
using Miruken.Callback;
using Miruken.Concurrency;
using Miruken.Context;
using System;
using static Miruken.Protocol;

namespace MajorLeagueMiruken.ServiceAgent.Test
{
    public interface ILeagueServiceAgent : IResolving
    {
        Promise LoadTeams();
    }
    public class LeagueServiceAgent : ContextualHandler, ILeagueServiceAgent
    {
        public Promise LoadTeams()
        {
            return Promise.Delay(TimeSpan.FromMilliseconds(10))
                .Then((s, a) =>
                {
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
                });
        }

        private void LoadTeam(
            string name, Color teamColor,
            string managerFirstName, string managerLastName,
            string coachFirstName, string coachLastName)
        {
            var league = P<ILeague>(Context);

            var team = league.CreateTeam();
            team.Name = name;
            team.TeamColor = teamColor;
            var manager = league.CreatePerson();
            manager.FirstName = managerFirstName;
            manager.LastName = managerLastName;
            team.Manager = manager;
            var coach = league.CreatePerson();
            coach.FirstName = coachFirstName;
            coach.LastName = coachLastName;
            team.Coach = coach;
        }
    }
}
