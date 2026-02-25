// <copyright file="BaseServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using Microsoft.Extensions.Logging;
    using System.Net.Http.Json;

    /// <summary>
    /// Base class for service clients.
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    public abstract class BaseServiceClient<TProfile>
        where TProfile : ServiceClientProfile
    {
        private readonly bool _throwExceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient{TService}"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="throwExceptions">A flag that will indicate the client should throw exceptions caught.</param>
        protected BaseServiceClient(IServiceManager<TProfile> serviceManager, ILogger<BaseServiceClient<TProfile>> logger, bool throwExceptions = false)
        {
            ServiceManager = serviceManager;
            Logger = logger;
            _throwExceptions = throwExceptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient{TService}"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        protected BaseServiceClient(IServiceManager<TProfile> serviceManager, ILogger<BaseServiceClient<TProfile>> logger)
        {
            ServiceManager = serviceManager;
            Logger = logger;
            _throwExceptions = false;
        }

        /// <summary>
        /// Gets the service manager.
        /// </summary>
        protected IServiceManager<TProfile> ServiceManager { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected ILogger<BaseServiceClient<TProfile>> Logger { get; }

        /// <summary>
        /// Performs a GET request and returns a nullable result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResult?> ExecuteNullableGet<TResult>(Uri uri, CancellationToken cancellationToken = default)
        {
            TResult? result = default;

            try
            {
                var message = await ServiceManager.GetAsync(uri, cancellationToken);

                if (message.IsSuccessStatusCode)
                {
                    result = await message.Content.ReadFromJsonAsync<TResult>(cancellationToken);
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An exception occurred for the uri: {Uri}", uri);

                if (_throwExceptions)
                {
                    throw;
                }
            }

            return result;
        }

        /// <summary>
        /// Performs a GET request and returns a default new instance if null.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResult> ExecuteGet<TResult>(Uri uri, CancellationToken cancellationToken = default)
            where TResult : new()
        {
            TResult? result = default;

            try
            {
                var message = await ServiceManager.GetAsync(uri, cancellationToken);

                if (message.IsSuccessStatusCode)
                {
                    result = await message.Content.ReadFromJsonAsync<TResult>(cancellationToken);
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An exception occurred for the uri: {Uri}", uri);

                if (_throwExceptions)
                {
                    throw;
                }
            }

            return result ?? new TResult();
        }

        /// <summary>
        /// Performs a GET request a returns a pre-defined default response if null.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to query against.</param>
        /// <param name="defaultResult">The default response to return in case of a null result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResult> ExecuteGet<TResult>(Uri uri, TResult defaultResult, CancellationToken cancellationToken = default)
        {
            TResult? result = default;

            try
            {
                var message = await ServiceManager.GetAsync(uri, cancellationToken);

                if (message.IsSuccessStatusCode)
                {
                    result = await message.Content.ReadFromJsonAsync<TResult>(cancellationToken);
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "An exception occurred for the uri: {Uri}", uri);

                if (_throwExceptions)
                {
                    throw;
                }
            }

            return result ?? defaultResult;
        }
    }
}