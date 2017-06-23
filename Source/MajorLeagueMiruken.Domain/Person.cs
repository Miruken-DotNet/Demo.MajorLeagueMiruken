using Assisticant.Fields;

namespace MajorLeagueMiruken.Domain
{
    public class Person
    {
        private Observable<Player> _player = new Observable<Player>();
        private Observable<string> _firstName = new Observable<string>();
        private Observable<string> _lastName = new Observable<string>();

        internal Player Player
        {
            get => _player;
            set => _player.Value = value;
        }

        internal Person()
        {
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName.Value = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName.Value = value;
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
