// <copyright file="DefaultBaseTranslatedServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    // Same file name for simplicity.
#pragma warning disable SA1649 // File name should match first type name
    public abstract class BaseTranslatedServiceClient : BaseTranslatedServiceClient<DefaultClientProfile>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="throwExceptions">A flag indicating if the client should throw exceptions.</param>
        protected BaseTranslatedServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger, ITranslator translator, bool throwExceptions = false)
            : base(serviceManager, logger, translator, throwExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        protected BaseTranslatedServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger, ITranslator translator)
            : base(serviceManager, logger, translator)
        {
        }
    }
}