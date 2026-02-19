// <copyright file="TranslatedPlanetServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.TranslatedPlanets
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;
    using SimpleServiceClient.Samples.Planets;

    /// <inheritdoc cref="ITranslatedPlanetClient" />
    public class TranslatedPlanetServiceClient : BaseTranslatedServiceClient<PlanetProfile>, ITranslatedPlanetClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedPlanetServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager"></param>
        /// <param name="logger"></param>
        /// <param name="translator"></param>
        public TranslatedPlanetServiceClient(IServiceManager<PlanetProfile> serviceManager, ILogger<BaseServiceClient<PlanetProfile>> logger, ITranslator translator)
            : base(serviceManager, logger, translator)
        {
        }

        /// <inheritdoc/>
        public async Task<TranslatedPlanet?> GetPlanet(int planetId, CancellationToken cancellationToken = default)
        {
            return await ExecuteNullableGet<Planet, TranslatedPlanet>(new Uri($"planets/{planetId}", UriKind.Relative), cancellationToken);
        }
    }
}