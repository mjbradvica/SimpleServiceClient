// <copyright file="BaseTranslatedServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TProfile"></typeparam>
    public abstract class BaseTranslatedServiceClient<TProfile> : BaseServiceClient<TProfile>
        where TProfile : ServiceClientProfile
    {
        private readonly ITranslator _translator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClient{TProfile}"/> class.
        /// </summary>
        /// <param name="serviceManager"></param>
        /// <param name="logger"></param>
        /// <param name="translator"></param>
        /// <param name="throwExceptions"></param>
        protected BaseTranslatedServiceClient(IServiceManager<TProfile> serviceManager, ILogger<BaseServiceClient<TProfile>> logger, ITranslator translator, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
            _translator = translator;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected async Task<TResponse?> ExecuteNullableGet<TResult, TResponse>(Uri uri, CancellationToken cancellationToken = default)
        {
            var response = await ExecuteNullableGet<TResult?>(uri, cancellationToken);

            return response == null
                ? default
                : _translator.Translate<TResult, TResponse>(response);
        }
    }
}