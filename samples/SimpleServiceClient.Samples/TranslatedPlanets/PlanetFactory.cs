// <copyright file="PlanetFactory.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.TranslatedPlanets
{
    using FactoryFoundation;
    using SimpleServiceClient.Samples.Planets;
    using System.Globalization;

    /// <inheritdoc />
    public class PlanetFactory :
        ICanTranslate<Planet, TranslatedPlanet>
    {
        /// <inheritdoc/>
        public TranslatedPlanet TranslateTo(Planet first)
        {
            return new TranslatedPlanet
            {
                Name = first.Name,
                Climate = first.Climate,
                Terrain = first.Terrain,
                Diameter = int.Parse(first.Diameter, new NumberFormatInfo()),
            };
        }
    }
}