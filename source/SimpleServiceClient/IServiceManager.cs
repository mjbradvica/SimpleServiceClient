// <copyright file="IServiceManager.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    /// <summary>
    /// Interface to interface with HTTP actions.
    /// </summary>
    /// <typeparam name="TProfile">The type of the client profile.</typeparam>
    public interface IServiceManager<TProfile>
        where TProfile : ServiceClientProfile
    {
        /// <summary>
        /// Performs a GET request against uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> GetAsync(Uri uri, CancellationToken cancellationToken = default);
    }

    /// <inheritdoc />
    public interface IServiceManager : IServiceManager<DefaultClientProfile>
    {
    }
}