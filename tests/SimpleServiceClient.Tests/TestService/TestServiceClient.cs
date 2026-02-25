// <copyright file="TestServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="ITestServiceClient" />
    public class TestServiceClient : BaseServiceClient, ITestServiceClient
    {
        /// <inheritdoc />
        public TestServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
        }

        /// <summary>
        /// Test value method.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T?> NullableGet<T>()
        {
            return await ExecuteNullableGet<T>(new Uri("https://www.test.com"), CancellationToken.None);
        }

        /// <summary>
        /// Test new default method.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T> NewDefaultGet<T>()
            where T : new()
        {
            return await ExecuteGet<T>(new Uri("https://www.test.com"), CancellationToken.None);
        }
    }
}