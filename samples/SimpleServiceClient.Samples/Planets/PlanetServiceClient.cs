// <copyright file="PlanetServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.Planets
{
    using Microsoft.Extensions.Logging;
    using SimpleServiceClient;

    /// <inheritdoc cref="IPlanetClient" />
    public class PlanetServiceClient : BaseServiceClient<PlanetProfile>, IPlanetClient
    {
        /// <inheritdoc />
        public PlanetServiceClient(IServiceManager<PlanetProfile> serviceManager, ILogger<BaseServiceClient<PlanetProfile>> logger)
            : base(serviceManager, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Planet?> GetPlanet(int planetId, CancellationToken cancellationToken = default)
        {
            return await ExecuteNullableGet<Planet>(new Uri($"planets/{planetId}", UriKind.Relative), cancellationToken);
        }
    }
}