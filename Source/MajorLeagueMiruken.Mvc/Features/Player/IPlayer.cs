namespace MajorLeagueMiruken.Mvc.Features.Player
{
    using Api;
    using Miruken.Callback;
    using Miruken.Concurrency;

    public interface IPlayer : IResolving
    {
        Promise<Player>   CreatePlayer(Player player);
        Promise           DeletePlayer(Player player);
        Promise<Player>   Player(int id);
        Promise<Player[]> Players();
        Promise<Player>   UpdatePlayer(Player player);
    }
}
