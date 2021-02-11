namespace MajorLeagueMiruken.Api
{
    using System.Collections.Generic;
    using System.Threading;
    using FluentValidation;
    using Miruken.Callback;

    public class PersonHandler
    {
        private int _counter;
        private readonly Dictionary<int, PersonData> _people = new (); 
            
        [Handles]
        public PersonResult Create(CreatePerson create)
        {
            create.Person.Id = Interlocked.Increment(ref _counter);
            _people.Add(create.Person.Id.Value, create.Person);
            return new PersonResult
            {
                Person = new PersonData
                {
                    Id = create.Person.Id 
                }
            };
        }
    }

    public class CreatePersonIntegrity : AbstractValidator<CreatePerson>
    {
        public CreatePersonIntegrity()
        {
            RuleFor(x => x.Person)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .SetValidator(new ValidatePerson())
                .OverridePropertyName("DataSource");
        } 
        
        private class ValidatePerson : AbstractValidator<PersonData>
        {
            public ValidatePerson()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            } 
        }
    }
}