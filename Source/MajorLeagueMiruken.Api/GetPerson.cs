namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record GetPerson(PersonData Person) : IRequest<PersonResult>;
}