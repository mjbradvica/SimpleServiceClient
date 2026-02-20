// <copyright file="TestServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class TestServiceClient : BaseServiceClient<TestProfile>
    {
        /// <inheritdoc />
        public TestServiceClient(IServiceManager<TestProfile> serviceManager, ILogger<BaseServiceClient<TestProfile>> logger, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
        }

        /// <summary>
        /// Test value method.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T?> GetValue<T>()
        {
            return await ExecuteNullableGet<T>(new Uri("https://www.test.com"), CancellationToken.None);
        }
    }
}