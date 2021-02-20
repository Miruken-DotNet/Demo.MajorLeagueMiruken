namespace MajorLeagueMiruken.Api.Person
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Validators;
    using Miruken.Api;
    using Miruken.Callback;
    using Miruken.Validate.FluentValidation;

    public class UpdatePersonIntegrity : AbstractValidator<UpdatePerson>
    {
        public UpdatePersonIntegrity()
        {
            RuleFor(x => x.Person).NotNull()
                .DependentRules(() =>
                {
                    RuleFor(p => p.Person.Id)
                        .Cascade(CascadeMode.Stop)
                        .NotNull().GreaterThan(0)
                        .WithComposerCustomAsync(PersonExists);
                    RuleFor(x => x.Person.FirstName)
                        .NotEmpty().Unless(x => x.Person.FirstName == null);
                    RuleFor(x => x.Person.LastName)
                        .NotEmpty().Unless(x => x.Person.LastName == null);
                });
        }
        
        private static async Task PersonExists(
            int?              id,
            CustomContext     context,
            CancellationToken cancel,
            IHandler          composer)
        {
            var person = await composer.StashGetOrPut(async () => 
                (await composer.Send(new GetPerson(new PersonData(id)))).Person);
            if (person == null)
                context.AddFailure("Person", $"Person with id {id} not found.");
        }
    }
}