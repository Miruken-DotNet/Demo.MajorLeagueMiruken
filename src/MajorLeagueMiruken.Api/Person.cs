namespace MajorLeagueMiruken.Api
{
    using System;

    public class Person
    {
        private DateTime? _birthDate;

        public int    Id        { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                    return null;

                return $"{FirstName} {LastName}";
            }
        }

        public DateTime? BirthDate {
            get { return _birthDate; }
            set
            {
                if (_birthDate == value) return;
                _birthDate = value;
            }
        }

        public int? Age
        {
            get
            {
                if (!BirthDate.HasValue)
                    return null;

               return DateTime.Today.Year - BirthDate.Value.Year;
            }
        }
    }
}
