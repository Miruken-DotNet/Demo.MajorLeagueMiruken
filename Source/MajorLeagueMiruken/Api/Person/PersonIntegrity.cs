namespace MajorLeagueMiruken.Api.Person
{
    using System;

    public static class PersonIntegrity
    {
        public static bool BeAValidAge(DateTime? date)
        {
            if (date == null) return true;
            var currentYear = DateTime.Now.Year;
            var dobYear     = date.Value.Year;
            return dobYear <= currentYear;
        }
    }
}