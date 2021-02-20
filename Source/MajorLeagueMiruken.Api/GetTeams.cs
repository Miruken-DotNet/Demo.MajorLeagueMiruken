namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record GetTeams(TeamData Team) : IRequest<TeamsResult>;
}