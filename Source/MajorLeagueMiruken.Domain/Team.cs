using Assisticant.Fields;

namespace MajorLeagueMiruken.Domain
{
    public class Team
    {
        private Observable<Person> _manager = new Observable<Person>();

        internal Team()
        {
        }

        public Person Manager
        {
            get => _manager;
            set => _manager.Value = value;
        }
    }
}