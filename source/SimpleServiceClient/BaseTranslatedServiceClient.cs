// <copyright file="BaseTranslatedServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Base service client for translated responses.
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    public abstract class BaseTranslatedServiceClient<TProfile> : BaseServiceClient<TProfile>
        where TProfile : ServiceClientProfile
    {
        private readonly ITranslator _translator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClient{TProfile}"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="throwExceptions">A flag that will indicate the client should throw exceptions caught.</param>
        protected BaseTranslatedServiceClient(IServiceManager<TProfile> serviceManager, ILogger<BaseServiceClient<TProfile>> logger, ITranslator translator, bool throwExceptions = false)
            : base(serviceManager, logger, throwExceptions)
        {
            _translator = translator;
        }

        /// <summary>
        /// Performs a GET request and returns a nullable translated response.
        /// </summary>
        /// <typeparam name="TResult">The type of the client result.</typeparam>
        /// <typeparam name="TResponse">The type of the final translated response.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to execute the request against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected async Task<TResponse?> ExecuteNullableGet<TResult, TResponse>(Uri uri, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteNullableGet<TResult?>(uri, cancellationToken);

            return result == null
                ? default
                : _translator.Translate<TResult, TResponse>(result);
        }

        /// <summary>
        /// Performs GET request and returns a translated response, or a translated default instance when null.
        /// </summary>
        /// <typeparam name="TResult">The type of the client result.</typeparam>
        /// <typeparam name="TResponse">The type of the final translated response.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to execute the request against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResponse> ExecuteGet<TResult, TResponse>(Uri uri, CancellationToken cancellationToken = default)
            where TResult : new()
        {
            var result = await ExecuteGet<TResult>(uri, cancellationToken);

            return _translator.Translate<TResult, TResponse>(result);
        }

        /// <summary>
        /// Performs a GET request and returns a translated response, or a translated response from a given default.
        /// </summary>
        /// <typeparam name="TResult">The type of the client result.</typeparam>
        /// <typeparam name="TResponse">The type of the final translated response.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to execute the request against.</param>
        /// <param name="defaultResponse">The default response to use in case of a null result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResponse> ExecuteGet<TResult, TResponse>(Uri uri, TResult defaultResponse, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteGet(uri, defaultResponse, cancellationToken);

            return _translator.Translate<TResult, TResponse>(result);
        }
    }
}