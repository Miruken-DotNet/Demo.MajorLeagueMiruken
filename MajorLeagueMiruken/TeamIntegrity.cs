namespace MajorLeagueMiruken
{
    using Api;
    using FluentValidation;

    public class TeamIntegrity : AbstractValidator<Team>
    {
        public TeamIntegrity()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.TeamColor).NotEmpty();
            RuleFor(x => x.Coach).NotNull();
            RuleFor(x => x.Coach).SetValidator(new CoachManagerIntegrity());
            RuleFor(x => x.Manager).SetValidator(new CoachManagerIntegrity());
        }
    }
}