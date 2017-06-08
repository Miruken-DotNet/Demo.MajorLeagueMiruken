namespace MajorLeagueMiruken.Wpf.App.Features.Players
{
    using CreateAPlayer;

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
