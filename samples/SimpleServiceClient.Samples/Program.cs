// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples
{
    using Microsoft.Extensions.DependencyInjection;
    using Polly;
    using Polly.CircuitBreaker;
    using Polly.Retry;
    using Polly.Timeout;
    using SimpleServiceClient.Registration;
    using SimpleServiceClient.Samples.People;
    using SimpleServiceClient.Samples.Planets;
    using SimpleServiceClient.Samples.TranslatedPlanets;
    using System.Reflection;

    /// <summary>
    /// Sample entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample entry point.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            var services = new ServiceCollection();

            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
                .AddCircuitBreaker(new CircuitBreakerStrategyOptions<HttpResponseMessage>())
                .AddTimeout(new TimeoutStrategyOptions())
                .AddRetry(new RetryStrategyOptions<HttpResponseMessage>())
                .Build();

            services.AddServiceClient<IPlanetClient, PlanetServiceClient, PlanetProfile>(
                client =>
                {
                    client.BaseAddress = new Uri("https://swapi.dev/api/");
                },
                pipeline);

            services.AddServiceClient<IPeopleClient, PeopleServiceClient>();

            services.AddTranslatedServiceClient<ITranslatedPlanetClient, TranslatedPlanetServiceClient, PlanetProfile>(
                client =>
                {
                    client.BaseAddress = new Uri("https://swapi.dev/api/");
                },
                pipeline,
                Assembly.GetExecutingAssembly());

            var provider = services.BuildServiceProvider();

            var planetClient = provider.GetRequiredService<ITranslatedPlanetClient>();

            var planet = await planetClient.GetPlanet(5, CancellationToken.None);

            var personClient = provider.GetRequiredService<IPeopleClient>();

            var person = await personClient.GetPerson(3, CancellationToken.None);

            Console.WriteLine(planet);
        }
    }
}