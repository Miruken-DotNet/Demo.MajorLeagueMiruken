using MajorLeagueMiruken.Wpf.App.Features.Teams.CreateATeam;

namespace MajorLeagueMiruken.Wpf.App.Features.Teams
{
    public class TeamsController: FeatureController
    {
        public void Show()
        {
            Show<TeamsView>();
        }

        public void CreateATeam()
        {
            Next<CreateATeamController>().Show();
        }
    }
}
