using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.MajorLeagueMiruken.Api
{
    public class Player: Person
    {
        public int Number { get; set; }
        public Team Team { get; set; }
    }
}
