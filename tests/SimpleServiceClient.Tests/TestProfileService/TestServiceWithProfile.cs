// <copyright file="TestServiceWithProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestProfileService
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="ITestServiceWithProfile" />
    public class TestServiceWithProfile : BaseServiceClient<TestServiceProfile>, ITestServiceWithProfile
    {
        /// <inheritdoc />
        public TestServiceWithProfile(IServiceManager<TestServiceProfile> serviceManager, ILogger<BaseServiceClient<TestServiceProfile>> logger)
            : base(serviceManager, logger)
        {
        }
    }
}