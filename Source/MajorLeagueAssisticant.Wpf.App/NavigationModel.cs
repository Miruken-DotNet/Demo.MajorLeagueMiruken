using Assisticant.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorLeagueAssisticant.Wpf.App
{
    enum NavigationMode
    {
        None,
        Teams,
        Players
    }
    class NavigationModel
    {
        private Observable<NavigationMode> _mode =
            new Observable<NavigationMode>(NavigationMode.None);

        public NavigationMode Mode
        {
            get => _mode;
            set => _mode.Value = value;
        }
    }
}
