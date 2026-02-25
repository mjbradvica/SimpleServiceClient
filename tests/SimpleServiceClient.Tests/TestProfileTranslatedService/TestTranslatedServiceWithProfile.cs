// <copyright file="TestTranslatedServiceWithProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestProfileTranslatedService
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="ITestTranslatedServiceWithProfile" />
    public class TestTranslatedServiceWithProfile : BaseTranslatedServiceClient<TestTranslatedServiceProfile>, ITestTranslatedServiceWithProfile
    {
        /// <inheritdoc />
        public TestTranslatedServiceWithProfile(IServiceManager<TestTranslatedServiceProfile> serviceManager, ILogger<BaseServiceClient<TestTranslatedServiceProfile>> logger, ITranslator translator)
            : base(serviceManager, logger, translator)
        {
        }

        /// <summary>
        /// Test nullable get method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<string?> TestNullableGet()
        {
            return await ExecuteNullableGet<string?, string?>(new Uri("https://www.test.com"), CancellationToken.None);
        }
    }
}