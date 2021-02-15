namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record GetTeam(TeamData Team) : IRequest<TeamResult>;
}