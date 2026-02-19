// <copyright file="ITranslatedPlanetClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.TranslatedPlanets
{
    /// <summary>
    /// Sample translated planet client.
    /// </summary>
    public interface ITranslatedPlanetClient
    {
        Task<TranslatedPlanet?> GetPlanet(int planetId, CancellationToken cancellationToken = default);
    }
}