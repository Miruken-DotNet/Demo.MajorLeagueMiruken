using Demo.MajorLeagueMiruken.Wpf.App.Features;
using Demo.MajorLeagueMiruken.Wpf.App.Features.MenuBar;
using Demo.MajorLeagueMiruken.Wpf.App.Features.Players;
using Demo.MajorLeagueMiruken.Wpf.App.Features.Teams;
using Miruken.Context;
using Miruken.Mvc;
using Miruken.Mvc.Options;

namespace Demo.MajorLeagueMiruken.Wpf.App
{
    public class AppController : FeatureController, IMenuBar
    {
        private IContext Content { get; set; }
        internal void Show()
        {
            Logger.Info("App starting...");

            Show<AppLayout>(layout =>
            {
                AddRegion(layout.MenuRegion, m => m.Show<MenuBarView>());
                Content = AddRegion(layout.ContentRegion, c => c.Show<TeamsView>());
            });
        }

        public void Teams()
        {
            Next<TeamsController>(IO.Animate(a=>a.Push.Left())).Show();
        }
        public void Players()
        {
            Next<PlayersController>(IO.Animate(a=>a.Push.Left())).Show();
        }
    }
}
