using Assisticant;
using Autofac;
using System.Reflection;

namespace MajorLeagueAssisticant.Wpf.App
{
    class MainScreen : ViewModelLocatorBase
    {
        private IContainer _container = BuildContainer();
        private NavigationModel _navigation;

        public MainScreen()
        {
            _navigation = _container.Resolve<NavigationModel>();
        }

        public object MenuViewport => ViewModel(() => _container.Resolve<Menu.MenuViewModel>());
        public object MasterViewport => ViewModel(() =>
            _navigation.Mode == NavigationMode.Teams ? _container.Resolve<Teams.TeamsViewModel>() :
            _navigation.Mode == NavigationMode.Players ? _container.Resolve<Players.PlayersViewModel>() :
            (object)null
        );
        public object DetailViewport => ViewModel(() =>
            _navigation.Mode == NavigationMode.Teams ? _container.Resolve<Teams.TeamDetailViewModel>() :
            _navigation.Mode == NavigationMode.Players ? _container.Resolve<Players.PlayerDetailViewModel>() :
            (object)null
        );

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly());

            builder.RegisterType<NavigationModel>()
                .AsSelf()
                .SingleInstance();

            return builder.Build();
        }
    }
}
