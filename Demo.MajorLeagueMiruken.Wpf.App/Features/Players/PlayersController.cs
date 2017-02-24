using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.MajorLeagueMiruken.Wpf.App.Features.Players
{
    public class PlayersController: FeatureController
    {
        public void Show()
        {
            Show<PlayersView>();
        }
    }
}
