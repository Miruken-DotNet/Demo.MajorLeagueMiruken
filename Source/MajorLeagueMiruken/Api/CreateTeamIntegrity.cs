namespace MajorLeagueMiruken.Api
{
    using FluentValidation;

    public class CreateTeamIntegrity : AbstractValidator<CreateTeam>
    {
        public CreateTeamIntegrity()
        {
            RuleFor(x => x.Team)
                .NotNull()
                .SetValidator(new TeamValidator());
        }
        
        private class TeamValidator : AbstractValidator<TeamData>
        {
            public TeamValidator()
            {
                RuleFor(x => x.Id).Null();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Color).NotNull();
                RuleFor(x => x.Coach).NotNull()
                    .SetValidator(new PersonValidator<CoachData>(
                        "Coach",  x => x.Person.Id));
                RuleFor(x => x.Manager).NotNull()
                    .SetValidator(new PersonValidator<ManagerData>(
                        "Manager", x => x.Person.Id));
                RuleForEach(x => x.Players)
                    .SetValidator(new PersonValidator<PlayerData>(
                        "Players", x => x.Person.Id));
            }
        }
    }
}