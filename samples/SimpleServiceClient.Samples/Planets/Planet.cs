// <copyright file="Planet.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.Planets
{
    /// <summary>
    /// Planet for test client.
    /// </summary>
    public class Planet
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name} - {Climate} - {Terrain}";
        }
    }
}