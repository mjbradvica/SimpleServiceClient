// <copyright file="TestTranslatedServiceProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestProfileTranslatedService
{
    /// <inheritdoc />
    public class TestTranslatedServiceProfile : ServiceClientProfile
    {
        /// <inheritdoc />
        public TestTranslatedServiceProfile(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}