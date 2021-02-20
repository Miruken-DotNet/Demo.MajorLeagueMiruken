namespace MajorLeagueMiruken.Api.Person
{
    using FluentValidation;

    public class CreatePersonIntegrity : AbstractValidator<CreatePerson>
    {
        public CreatePersonIntegrity()
        {
            RuleFor(x => x.Person).NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Person.Id).Null();
                    RuleFor(x => x.Person.FirstName).NotEmpty();
                    RuleFor(x => x.Person.LastName).NotEmpty();
                });
        }
    }
}