namespace MajorLeagueMiruken
{
    using Api;
    using FluentValidation;

    public class CoachManagerIntegrity : AbstractValidator<Person>
    {
        public CoachManagerIntegrity()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}