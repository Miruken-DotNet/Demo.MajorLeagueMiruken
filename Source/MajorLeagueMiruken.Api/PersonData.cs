namespace MajorLeagueMiruken.Api
{
    using System;
    public class PersonData
    {
        public int?      Id        { get; set; }
        public string    FirstName { get; set; }
        public string    LastName  { get; set; }
        public DateTime? Birthdate { get; set; }

        public string FullName
        {
            get
            {
                if(!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName)) return null;
                return $"{FirstName ?? ""} ${LastName ?? ""}";
            }
        }

        public int? Age => Birthdate.HasValue ? DateTime.Today.Year - Birthdate.Value.Year : null;
    }

}