namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record UpdatePerson(PersonData Person) : IRequest<PersonResult>;
}