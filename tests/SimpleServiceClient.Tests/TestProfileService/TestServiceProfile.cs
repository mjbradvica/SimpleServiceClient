// <copyright file="TestServiceProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestProfileService
{
    /// <inheritdoc />
    public class TestServiceProfile : ServiceClientProfile
    {
        /// <inheritdoc />
        public TestServiceProfile(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}