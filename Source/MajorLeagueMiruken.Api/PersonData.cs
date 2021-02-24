namespace MajorLeagueMiruken.Api
{
    using System;
    
    public record PersonData(
        int?      Id        = null, 
        string    FirstName = null,
        string    LastName  = null, 
        DateTime? Birthdate = null)
    {
        public int? Age
        {
            get
            {
                if (!Birthdate.HasValue) return null;
                var today = DateTime.Today;
                var age = today.Year - Birthdate.Value.Year;
                if (Birthdate.Value.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}