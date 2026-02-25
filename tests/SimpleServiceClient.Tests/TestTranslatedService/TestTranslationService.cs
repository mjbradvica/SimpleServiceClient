// <copyright file="TestTranslationService.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestTranslatedService
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="ITestTranslationService" />
    public class TestTranslationService : BaseTranslatedServiceClient, ITestTranslationService
    {
        /// <inheritdoc />
        public TestTranslationService(IServiceManager serviceManager, ILogger<BaseServiceClient> logger, ITranslator translator)
            : base(serviceManager, logger, translator)
        {
        }
    }
}