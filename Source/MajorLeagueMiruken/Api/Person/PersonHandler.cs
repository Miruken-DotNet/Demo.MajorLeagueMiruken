namespace MajorLeagueMiruken.Api.Person
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Miruken.Callback;

    public class PersonHandler
    {
        private int _counter;
        private readonly Dictionary<int, PersonData> _people = new ();

        [Handles]
        public PersonResult Get(GetPerson get) => new(Find(get.Person));

        [Handles]
        public PersonResult Create(CreatePerson create)
        {
            var person = create.Person with
            {
                Id = Interlocked.Increment(ref _counter)
            };
            _people.Add(person.Id ?? 0, person);

            return new PersonResult(new PersonData(person.Id ?? 0));
        }

        [Handles]
        public PersonResult Update(UpdatePerson update, PersonData person)
        {
            var changes = update.Person;
            
            if (changes.FirstName != null)
                person = person with { FirstName = changes.FirstName };
            
            if (changes.LastName != null)
                person = person with { LastName = changes.LastName };
            
            if (changes.Birthdate != null)
                person = person with { Birthdate = changes.Birthdate };

            _people[person.Id ?? 0] = person;
            
            return new PersonResult(person);
        }

        [Handles]
        public PersonResult Delete(DeletePerson delete)
        {
            var person = Find(delete.Person);
            if (person != null)
                _people.Remove(person.Id ?? 0);
            
            return new PersonResult(person);
        }

        private PersonData Find(PersonData filter) =>
            _people.Values.FirstOrDefault(p => filter == null ||
                filter.Id        == null || p.Id        == filter.Id &&
                filter.FirstName == null || p.FirstName == filter.FirstName &&
                filter.LastName  == null || p.LastName  == filter.LastName &&
                filter.Birthdate == null || p.Birthdate == filter.Birthdate);
    }
}