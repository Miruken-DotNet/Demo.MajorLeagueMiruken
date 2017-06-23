namespace MajorLeagueMiruken.Domain
{
    public class Player
    {
        private readonly Person _person;
        private readonly Team _team;

        internal Player(Person person, Team team)
        {
            _person = person;
            _team = team;
        }

        public Person Person => _person;
        public Team Team => _team;
    }
}