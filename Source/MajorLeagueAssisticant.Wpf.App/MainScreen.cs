using Assisticant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorLeagueAssisticant.Wpf.App
{
    class MainScreen : ViewModelLocatorBase
    {
        public object MenuViewport => ViewModel(() => new Menu.MenuViewModel());
        public object MasterViewport => ViewModel(() => new Teams.TeamsViewModel());
        public object DetailViewport => ViewModel(() => new Teams.TeamDetailViewModel());
    }
}
