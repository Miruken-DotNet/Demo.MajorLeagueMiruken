namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record CreatePerson(PersonData Person) : IRequest<PersonResult>;
}