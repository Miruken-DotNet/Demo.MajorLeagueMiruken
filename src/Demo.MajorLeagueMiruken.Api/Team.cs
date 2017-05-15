using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.MajorLeagueMiruken.Api
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color TeamColor { get; set; }
        public Person Coach { get; set; }
        public Person Manager { get; set; }
        public Player[] Roster { get; set; }
    }
}
