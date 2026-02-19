// <copyright file="PlanetProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.Planets
{
    using SimpleServiceClient.Clients;

    /// <inheritdoc />
    public class PlanetProfile : ServiceClientProfile
    {
        /// <inheritdoc />
        public PlanetProfile(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}