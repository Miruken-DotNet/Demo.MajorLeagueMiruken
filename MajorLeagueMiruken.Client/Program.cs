namespace MajorLeagueMiruken.Client
{
    using System;
    using System.Threading.Tasks;
    using Api;
    using Microsoft.Extensions.DependencyInjection;
    using Miruken.Api;
    using Miruken.Api.Route;
    using Miruken.Http;
    using Miruken.Register;

    class Program
    {
        private const string WebHost = "https://localhost:5001/";

        static async Task Main(string[] args)
        {
            var handler = new ServiceCollection()
                .AddMiruken(options => options.WithHttp())
                .Build();

            var result = await handler.Send(new CreatePerson(
                    new PersonData(
                        FirstName: "Michael",
                        LastName:  "Dudley",
                        Birthdate: new DateTime(1977, 8, 28)
                    )).RouteTo(WebHost));
            
            Console.WriteLine(result.Person.Id);
        }
    }
}