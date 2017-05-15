namespace Demo.MajorLeagueMiruken.Wpf.App.Features.Players
{
    using Demo.MajorLeagueMiruken.Wpf.App.Features.Players.CreateAPlayer;
    public class PlayersController: FeatureController
    {
        public void Show()
        {
            Show<PlayersView>();
        }
        public void CreateAPlayer()
        {
            Next<CreateAPlayerController>().Show();
        }
    }
}
