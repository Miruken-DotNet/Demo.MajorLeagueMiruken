namespace MajorLeagueMiruken.Api.Team
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Miruken.Api;
    using Miruken.Callback;

    public class TeamHandler
    {
        private int _counter;
        private readonly Dictionary<int, TeamData> _teams = new ();
        
        [Handles]
        public TeamsResult Get(GetTeams get) => new(Find(get.Team).ToArray());
        
        [Handles]
        public async Task<TeamResult> Create(
            CreateTeam create,
            IHandler   composer)
        {
            var team    = create.Team;
            var coach   = team.Coach;
            var manager = team.Manager;
            var players = team.Players;
            
            team = team with
            {
                Id = Interlocked.Increment(ref _counter),
                Coach = coach with
                {
                    Person = await GetOrCreatePerson(coach.Person, composer)
                },
                Manager = manager with
                {
                    Person = await GetOrCreatePerson(manager.Person, composer)
                },
                Players = await Task.WhenAll(players.Select(async player => player with
                {
                    Person = await GetOrCreatePerson(player.Person, composer)
                }))
            };
            _teams.Add(team.Id ?? 0, team);

            return new TeamResult(new TeamData(team.Id ?? 0));
        }

        [Handles]
        public TeamResult Update(UpdateTeam update, TeamData team)
        {
            var changes = update.Team;
            
            if (changes.Name != null)
                team = team with { Name = changes.Name };
            
            if (changes.Color != null)
                team = team with { Color = changes.Color };

            var coach = changes.Coach;
            if (coach != null)
            {
                if (coach.License != null)
                    coach = coach with { License = coach.License };
                if (coach.Person.Id != null)
                    coach = coach with { Person = new PersonData(coach.Person.Id) };
                team = team with { Coach = coach };
            }

            var manager = changes.Manager;
            if (manager != null)
            {
                if (manager.Person.Id != null)
                    manager = manager with { Person = new PersonData(manager.Person.Id) };
                team = team with { Manager = manager };
            }
            
            _teams[team.Id ?? 0] = team;
            
            return new TeamResult(team);
        }
        
        private IEnumerable<TeamData> Find(TeamData filter) =>
            _teams.Values.Where(t => filter == null ||
               filter.Id    == null           || t.Id    == filter.Id &&
               filter.Name  == null           || t.Name  == filter.Name &&
               filter.Color == null           || t.Color == filter.Color &&
               filter.Coach?.Person   == null || t.Coach.Person.Id   == filter.Coach.Person.Id &&
               filter.Manager?.Person == null || t.Manager.Person.Id == filter.Manager.Person.Id);

        private static async Task<PersonData> GetOrCreatePerson(
            PersonData person, IHandler composer) => person.Id.HasValue
                ? new PersonData(person.Id)
                : (await composer.Send(new CreatePerson(person))).Person;
    }
}