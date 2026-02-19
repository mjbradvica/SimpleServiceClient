// <copyright file="BaseServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using System.Net.Http.Json;

    /// <summary>
    /// Base class for service clients.
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    public abstract class BaseServiceClient<TProfile>
        where TProfile : ServiceClientProfile
    {
        private readonly IServiceManager<TProfile> _serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient{TService}"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager{T}"/> interface.</param>
        protected BaseServiceClient(IServiceManager<TProfile> serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Performs a GET request and attempts to resolve the result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<TResult?> ExecuteGet<TResult>(Uri uri, CancellationToken cancellationToken = default)
        {
            var message = await _serviceManager.GetAsync(uri, cancellationToken);

            TResult? result = default;

            if (message.IsSuccessStatusCode)
            {
                result = await message.Content.ReadFromJsonAsync<TResult>(cancellationToken);
            }

            return result;
        }
    }
}