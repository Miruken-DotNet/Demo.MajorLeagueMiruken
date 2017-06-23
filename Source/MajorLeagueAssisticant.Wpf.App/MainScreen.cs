using Assisticant;
using Autofac;
using System.Reflection;

namespace MajorLeagueAssisticant.Wpf.App
{
    class MainScreen : ViewModelLocatorBase
    {
        private IContainer _container = BuildContainer();

        public object MenuViewport => ViewModel(() => _container.Resolve<Menu.MenuViewModel>());
        public object MasterViewport => ViewModel(() => _container.Resolve<Teams.TeamsViewModel>());
        public object DetailViewport => ViewModel(() => _container.Resolve<Teams.TeamDetailViewModel>());

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly());

            return builder.Build();
        }
    }
}
