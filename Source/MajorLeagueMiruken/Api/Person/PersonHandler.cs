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
        public PeopleResult Find(FindPeople find) => new(Match(find.Filter).ToArray());

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
        public PeopleResult Delete(DeletePeople delete)
        {
            var people = Match(delete.Filter).ToArray();
            
            foreach (var person in people)
                _people.Remove(person.Id ?? 0);

            return new PeopleResult(people);
        }

        private IEnumerable<PersonData> Match(PersonData filter) =>
            _people.Values.Where(p => filter == null ||
                (filter.Id        == null || p.Id        == filter.Id) &&
                (filter.FirstName == null || p.FirstName == filter.FirstName) &&
                (filter.LastName  == null || p.LastName  == filter.LastName) &&
                (filter.Birthdate == null || p.Birthdate == filter.Birthdate));
    }
}