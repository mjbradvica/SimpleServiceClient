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

        /// <inheritdoc />
        public TestTranslatedServiceWithProfile(IServiceManager<TestTranslatedServiceProfile> serviceManager, ILogger<BaseServiceClient<TestTranslatedServiceProfile>> logger, ITranslator translator, bool throwExceptions)
            : base(serviceManager, logger, translator, throwExceptions)
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

        /// <summary>
        /// Test default constructor new method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<TestNewResponse> TestNewGet()
        {
            return await ExecuteGet<TestNewResponse, TestNewResponse>(new Uri("https://www.test.com"), CancellationToken.None);
        }

        /// <summary>
        /// Default value get.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<TestNewResponse> TestDefaultResponseGet()
        {
            return await ExecuteGet<TestNewResponse, TestNewResponse>(new Uri("https://www.test.com"), new TestNewResponse(), CancellationToken.None);
        }
    }
}