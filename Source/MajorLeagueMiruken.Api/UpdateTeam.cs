namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record UpdateTeam(TeamData Team) : IRequest<PersonResult>;
}