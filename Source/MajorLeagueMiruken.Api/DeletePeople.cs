namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record DeletePeople(PersonData Filter) : IRequest<PeopleResult>;
}