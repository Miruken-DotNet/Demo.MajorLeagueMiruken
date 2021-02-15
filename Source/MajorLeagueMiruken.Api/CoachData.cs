namespace MajorLeagueMiruken.Api
{
    public record CoachData(PersonData Person, int? Age = null, string License = null);
}