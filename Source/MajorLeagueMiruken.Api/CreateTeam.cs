namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record CreateTeam(TeamData Team) : IRequest<TeamResult>;
}