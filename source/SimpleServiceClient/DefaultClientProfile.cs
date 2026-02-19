// <copyright file="DefaultClientProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    /// <inheritdoc />
    public class DefaultClientProfile : ServiceClientProfile
    {
        /// <inheritdoc />
        public DefaultClientProfile(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}