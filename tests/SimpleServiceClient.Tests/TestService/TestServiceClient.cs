// <copyright file="TestServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    using SimpleServiceClient.Abstractions;
    using SimpleServiceClient.Clients;

    /// <inheritdoc />
    public class TestServiceClient : BaseServiceClient<TestProfile>
    {
        /// <inheritdoc />
        public TestServiceClient(IServiceManager<TestProfile> serviceManager)
            : base(serviceManager)
        {
        }

        /// <summary>
        /// Test value method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T?> GetValue<T>()
        {
            return await ExecuteGet<T>(new Uri("https://www.test.com"), CancellationToken.None);
        }
    }
}