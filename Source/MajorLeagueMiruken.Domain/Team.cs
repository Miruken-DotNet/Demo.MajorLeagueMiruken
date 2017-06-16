using System;
using Assisticant.Fields;
using System.Collections.Generic;
using Assisticant.Collections;

namespace MajorLeagueMiruken.Domain
{
    public class Team
    {
        private Observable<Person> _manager = new Observable<Person>();
        private ObservableList<Player> _roster = new ObservableList<Player>();

        internal Team()
        {
        }

        public Person Manager
        {
            get => _manager;
            set => _manager.Value = value;
        }

        public IEnumerable<Player> Roster => _roster;

        public Player AddPlayer(Person person)
        {
            var player = new Player(person, this);
            _roster.Add(player);
            if (person.Player != null)
            {
                person.Player.Team._roster.Remove(person.Player);
            }
            person.Player = player;
            return player;
        }
    }
}