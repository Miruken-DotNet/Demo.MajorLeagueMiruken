namespace MajorLeagueMiruken.Api.Person
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Validators;
    using Miruken.Api;
    using Miruken.Callback;
    using Miruken.Validate.FluentValidation;

    public class PersonValidator<TRole> : AbstractValidator<TRole>
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
                        PersonExists(id, role, context, composer));
            });
        }
        
        private static async Task PersonExists(
            int?              id,
            string            property,
            CustomContext     context,
            IHandler          composer)
        {
            var person = (await composer.Send(new GetPerson(new PersonData(id)))).Person;
            if (person == null)
                context.AddFailure(property, $"Person with id {id} not found.");
        }
    }
}