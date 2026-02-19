// <copyright file="TranslatedPlanet.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.TranslatedPlanets
{
    /// <summary>
    /// Sample translated planet.
    /// </summary>
    public class TranslatedPlanet
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets the client.
        /// </summary>
        public string Climate { get; init; } = string.Empty;

        /// <summary>
        /// Gets the terrain.
        /// </summary>
        public string Terrain { get; init; } = string.Empty;

        /// <summary>
        /// Gets the diameter.
        /// </summary>
        public int Diameter { get; init; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name} - {Diameter}";
        }
    }
}