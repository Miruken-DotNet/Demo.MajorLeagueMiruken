namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record FindPeople(PersonData Filter) : IRequest<PersonResult>;
}