// <copyright file="DefaultBaseServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using Microsoft.Extensions.Logging;

    // Same class name for simplicity of API.
#pragma warning disable SA1649 // File name should match first type name
    /// <inheritdoc />
    public abstract class BaseServiceClient : BaseServiceClient<DefaultClientProfile>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="throwExceptions">A flag to indicate if the service should throw exceptions.</param>
        protected BaseServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        protected BaseServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger)
            : base(serviceManager, logger)
        {
        }
    }
}