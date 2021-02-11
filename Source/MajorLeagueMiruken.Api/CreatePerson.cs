namespace MajorLeagueMiruken.Api
{
    using Miruken.Api;
    
    public class CreatePerson : IRequest<PersonResult>
    {
        public PersonData Person { get; set; }
    }
    
    public class PersonResult
    {
       public PersonData Person { get; set; }
    }
}