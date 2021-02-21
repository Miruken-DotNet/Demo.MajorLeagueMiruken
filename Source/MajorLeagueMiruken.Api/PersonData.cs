namespace MajorLeagueMiruken.Api
{
    using System;
    
    public record PersonData(
        int?      Id        = null, 
        string    FirstName = null,
        string    LastName  = null, 
        DateTime? Birthdate = null)
    {
        public int? Age => Birthdate.HasValue 
            ? DateTime.Today.Year - Birthdate.Value.Year 
            : null;
    }
}