// <copyright file="TestProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    /// <inheritdoc />
    public class TestProfile : ServiceClientProfile
    {
        /// <inheritdoc />
        public TestProfile(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}