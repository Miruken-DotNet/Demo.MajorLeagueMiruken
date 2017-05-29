namespace MajorLeagueMiruken.Wpf.App
{
    using Features;
    using Features.Header;
    using Features.Players;
    using Features.Teams;
    using Miruken.Context;
    using Miruken.Mvc.Options;
    using Mvc.Features.Team;

    public class AppController : FeatureController, IHeader
    {
        private IContext Content { get; set; }
        internal void Show()
        {
            Logger.Info("App starting...");

            Show<AppLayout>(layout =>
            {
                AddRegion(layout.MenuRegion, m => m.Show<HeaderView>());
                Content = AddRegion(layout.ContentRegion, c => c.Show<ITeamsView>());
            });
        }

        public void Teams()
        {
            Next<TeamsController>(Content.Animate(a=>a.Push.Left())).Show();
        }
        public void Players()
        {
            Next<PlayersController>(Content.Animate(a=>a.Push.Right())).Show();
        }
        public void CreateATeam()
        {
            Next<PlayersController>(Content.Animate(a => a.Push.Right())).Show();
        }
    }
}
