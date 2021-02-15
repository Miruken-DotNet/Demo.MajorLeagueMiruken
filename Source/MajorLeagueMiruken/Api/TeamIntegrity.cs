namespace MajorLeagueMiruken.Api
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Validators;
    using Miruken.Api;
    using Miruken.Callback;
    using Miruken.Validate.FluentValidation;

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
                    .WithComposerCustomAsync(TeamIntegrity.TeamExists);
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
    }

    internal class PersonValidator<TRole> : AbstractValidator<TRole>
    {
        public PersonValidator(string role,
            Expression<Func<TRole, int?>> personId)
        {
            When(x => personId.Compile()(x) != null, () =>
            {
                RuleFor(personId)
                    .Cascade(CascadeMode.Stop)
                    .GreaterThan(0)
                    .WithComposerCustomAsync((id, context, _, composer) =>
                        TeamIntegrity.PersonExists(id, role, context, composer));
            });
        }
    }
    
    internal static class TeamIntegrity
    {
        internal static async Task PersonExists(
            int?              id,
            string            property,
            CustomContext     context,
            IHandler          composer)
        {
            var person = (await composer.Send(new GetPerson(new PersonData(id)))).Person;
            if (person == null)
                context.AddFailure(property, $"Person with id {id} not found.");
        }
        
        internal static async Task TeamExists(
            int?              id,
            CustomContext     context,
            CancellationToken cancel,
            IHandler          composer)
        {
            var team = await composer.StashGetOrPut(async () => 
                (await composer.Send(new GetTeam(new TeamData(id)))).Team);
            if (team == null)
                context.AddFailure("Team", $"Team with id {id} not found.");
        }
    }
}