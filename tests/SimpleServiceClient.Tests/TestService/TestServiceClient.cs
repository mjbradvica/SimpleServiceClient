// <copyright file="TestServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class TestServiceClient : BaseServiceClient<TestProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="throwExceptions">A flag determining if an exceptions should throw.</param>
        public TestServiceClient(IServiceManager<TestProfile> serviceManager, ILogger<BaseServiceClient<TestProfile>> logger, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
        }

        /// <summary>
        /// Test value method.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T?> GetValue<T>()
        {
            return await ExecuteNullableGet<T>(new Uri("https://www.test.com"), CancellationToken.None);
        }
    }
}