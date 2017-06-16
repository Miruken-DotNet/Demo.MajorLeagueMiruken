using Assisticant.Fields;

namespace MajorLeagueMiruken.Domain
{
    public class Person
    {
        private Observable<Player> _player = new Observable<Player>();

        internal Player Player
        {
            get => _player;
            set => _player.Value = value;
        }

        internal Person()
        {
        }
    }
}
