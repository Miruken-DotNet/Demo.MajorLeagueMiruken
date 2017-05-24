namespace Demo.MajorLeagueMiruken.Wpf.App.Features
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Castle.Core.Logging;
    using FluentValidation;

    public abstract class FeatureController: Miruken.Mvc.Controller, IGuarded
    {
        private int _guarded;
        public bool Guard(bool guard)
        {
            throw new NotImplementedException();
        }
        public bool Guarded => _guarded != 0;
        public bool Unguarded => _guarded != 1;
        bool IGuarded.Guard(bool guard)
        {
            var guardInt = guard ? 1 : 0;
            if (Interlocked.CompareExchange(ref _guarded,
                guardInt, guardInt ^ 1) == guardInt)
                return false;
            ChangeProperty(0, 1, null, null, "Guarded");
            ChangeProperty(0, 1, null, null, "Unguarded");
            return true;
        }
        protected string GetExceptionDetails(Exception exception, bool showProperties)
        {
            var validation = exception as ValidationException;
            if (validation == null) return exception.Message;
            var details = new StringBuilder();
            var failures = validation.Errors.GroupBy(e => e.PropertyName);
            foreach (var failure in failures)
            {
                var hasProperty = showProperties && !string.IsNullOrEmpty(failure.Key);
                if (hasProperty) details.AppendLine(failure.Key);
                foreach (var error in failure)
                {
                    if (hasProperty) details.Append("  \u2022 ");
                    details.AppendLine(error.ErrorMessage);
                }
                details.AppendLine();
            }
            return details.ToString();
        }
        public ILogger Logger { get; set; } = NullLogger.Instance;

    }
}
