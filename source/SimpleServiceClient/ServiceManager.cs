// <copyright file="ServiceManager.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using System.Net.Http.Json;

    /// <inheritdoc />
    public class ServiceManager<TProfile> : IServiceManager<TProfile>
        where TProfile : ServiceClientProfile
    {
        private readonly TProfile _profile;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager{T}"/> class.
        /// </summary>
        /// <param name="profile">An implementation of the <see cref="ServiceClientProfile"/> abstraction.</param>
        public ServiceManager(TProfile profile)
        {
            _profile = profile;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.GetAsync(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<string> GetStringAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.GetStringAsync(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.GetStreamAsync(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<byte[]> GetByteArrayAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.GetByteArrayAsync(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TResult?> GetFromJsonAsync<TResult>(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.GetFromJsonAsync<TResult>(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PostAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PostAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PostAsJsonAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PutAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PutAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PutAsJsonAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PatchAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PatchAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> PatchAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.PatchAsJsonAsync(uri, content, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.DeleteAsync(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TContent?> DeleteFromJsonAsync<TContent>(Uri uri, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.DeleteFromJsonAsync<TContent>(uri, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken = default)
        {
            return await _profile.Client.SendAsync(message, cancellationToken);
        }
    }
}