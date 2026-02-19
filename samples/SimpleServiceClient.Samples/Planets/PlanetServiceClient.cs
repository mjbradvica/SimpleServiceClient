// <copyright file="PlanetServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.Planets
{
    using SimpleServiceClient;

    /// <inheritdoc cref="IPlanetClient" />
    public class PlanetServiceClient : BaseServiceClient<PlanetProfile>, IPlanetClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{TService}"/> profile.</param>
        public PlanetServiceClient(IServiceManager<PlanetProfile> serviceManager)
            : base(serviceManager)
        {
        }

        /// <inheritdoc/>
        public async Task<Planet?> GetPlanet(int planetId, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<Planet>(new Uri($"planets/{planetId}", UriKind.Relative), cancellationToken);
        }
    }
}