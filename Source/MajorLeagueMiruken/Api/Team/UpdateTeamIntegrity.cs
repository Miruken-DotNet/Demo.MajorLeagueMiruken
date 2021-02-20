namespace MajorLeagueMiruken.Api.Team
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Validators;
    using Miruken.Api;
    using Miruken.Callback;
    using Miruken.Validate.FluentValidation;
    using Person;

    public class UpdateTeamIntegrity : AbstractValidator<UpdateTeam>
    {
        public UpdateTeamIntegrity()
        {
            RuleFor(x => x.Team).NotNull()
                .SetValidator(new TeamValidator());
        }
        
        private class TeamValidator : AbstractValidator<TeamData>
        {
            public TeamValidator()
            {
                RuleFor(x => x.Id)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().GreaterThan(0)
                    .WithComposerCustomAsync(TeamExists);
                RuleFor(x => x.Name).NotEmpty()
                    .Unless(x => x.Name == null);
                RuleFor(x => x.Coach)
                    .SetValidator(new PersonValidator<CoachData>(
                        "Coach", x => x.Person.Id))
                    .When(x => x.Coach != null);
                RuleFor(x => x.Manager)
                    .SetValidator(new PersonValidator<ManagerData>(
                        "Manager", x => x.Person.Id))
                    .When(x => x.Manager != null);
                RuleForEach(x => x.Players)
                    .SetValidator(new PersonValidator<PlayerData>(
                        "Players", x => x.Person.Id));
            }
        }
        
        private static async Task TeamExists(
            int?              id,
            CustomContext     context,
            CancellationToken cancel,
            IHandler          composer)
        {
            var team = await composer.StashGetOrPut(async () => 
                (await composer.Send(new GetTeams(new TeamData(id))))
                    .Teams.SingleOrDefault());
            if (team == null)
                context.AddFailure("Team", $"Team with id {id} not found.");
        }
    }
}