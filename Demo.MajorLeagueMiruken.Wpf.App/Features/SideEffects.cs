using System;
using Miruken.Mvc.Views;
using Miruken.Callback;
using static Miruken.Protocol;
using Miruken.Mvc.Options;

namespace Demo.MajorLeagueMiruken.Wpf.App.Features
{
    public static class SideEffects
    {
        public static IHandler Guard(this IHandler handler, IGuarded guarded)
        {
            if (guarded == null) return handler;
            bool? guard = null;
            return handler.Aspect((_, composer) =>
                guard = guarded.Guard(true),
                (_, composer, state) =>
                {
                    if (guard == true) guarded.Guard(false);
                });
        }

        public static IHandler Overlay<W>(
            this IHandler handler) where W : IView
        {
            return Overlay<W>(handler, null);
        }

        public static IHandler Overlay<W>(
            this IHandler handler, Action<W> init) where W : IView
        {
            return handler.Aspect((_, composer) =>
                P<IViewRegion>(composer.Overlay()).Show(init));
        }
    }
}
