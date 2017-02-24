using System.Configuration;
using System.Windows;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Improving.MediatR;
using Miruken.Callback;
using Miruken.Castle;
using Miruken.Context;
using Miruken.Mvc;
using Miruken.Mvc.Castle;
using Miruken.Mvc.Options;
using Miruken.Mvc.Wpf;

namespace Demo.MajorLeagueMiruken.Wpf.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContext _appContext = new Context();

        public App()
        {
            var windsor = new WindsorHandler(container =>
            {
                container
                    .AddFacility<LoggingFacility>(f => f.UseNLog())
                    .Install(
                        new MvcInstaller(Classes.FromThisAssembly()),
                        new ConfigurationFactoryInstaller(Types.FromThisAssembly()),
                        new ResolvingInstaller(Classes.FromThisAssembly())
                        //,new MediatRInstaller(
                        //    Classes.FromThisAssembly())
                    );
            });

            _appContext.ContextEnded += _ =>
            {
                windsor.Dispose();
            };

            _appContext.AddHandlers(windsor, new NavigateHandler(new ViewRegion()));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _appContext.NewWindow(w => w
                .Name("Main")
                .Title("Major League Miruken")
                .PrimaryScreen().FullScreen())
                .Push<AppController>().Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _appContext.End();
        }
    }
}
