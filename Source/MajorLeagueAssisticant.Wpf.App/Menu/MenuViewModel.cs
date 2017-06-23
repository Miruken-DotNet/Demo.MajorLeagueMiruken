using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorLeagueAssisticant.Wpf.App.Menu
{
    class MenuViewModel
    {
        private NavigationModel _navigation;

        public MenuViewModel(NavigationModel navigation)
        {
            _navigation = navigation;
        }

        public void Home()
        {
            _navigation.Mode = NavigationMode.None;
        }

        public void Teams()
        {
            _navigation.Mode = NavigationMode.Teams;
        }

        public void Players()
        {
            _navigation.Mode = NavigationMode.Players;
        }
    }
}
