namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;

    public record DeletePerson(PersonData Person) : IRequest<PersonResult>;
}