// <copyright file="IPlanetClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.Planets
{
    /// <summary>
    /// Interface to interface with planet client.
    /// </summary>
    public interface IPlanetClient
    {
        /// <summary>
        /// Attempts to retrieve a planet.
        /// </summary>
        /// <param name="planetId">The identifier of the planet.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Planet?> GetPlanet(int planetId, CancellationToken cancellationToken = default);
    }
}