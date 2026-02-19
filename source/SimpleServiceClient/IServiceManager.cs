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
        /// Performs a GET request against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> GetAsync(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a GET request for a String against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<string> GetStringAsync(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a GET request for a Stream against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a GET request for a Byte array against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<byte[]> GetByteArrayAsync(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a GET request for the specified type against a uri.
        /// </summary>
        /// <typeparam name="TResult">The type to deserialize from.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to query against.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TResult?> GetFromJsonAsync<TResult>(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a POST request against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to post against.</param>
        /// <param name="content">A <see cref="HttpContent"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a POST request using json against a uri.
        /// </summary>
        /// <typeparam name="TContent">The type of the content to serialize.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to post against.</param>
        /// <param name="content">An object to serialize.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PostAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a PUT request against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="content">An <see cref="HttpContent"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a PUT request using json against a uri.
        /// </summary>
        /// <typeparam name="TContent">The type of the content to serialize.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="content">An instance of the content.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PutAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a PATCH request against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="content">An <see cref="HttpContent"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PatchAsync(Uri uri, HttpContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a PATCH request using json against a uri.
        /// </summary>
        /// <typeparam name="TContent">The type of the content to serialize.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="content">An instance of the content.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> PatchAsJsonAsync<TContent>(Uri uri, TContent content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a DELETE request against a uri.
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> DeleteAsync(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a DELETE request using json against a uri.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to send the request to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TResult?> DeleteFromJsonAsync<TResult>(Uri uri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a user defined request.
        /// </summary>
        /// <param name="message">A <see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken = default);
    }

    /// <inheritdoc />
    public interface IServiceManager : IServiceManager<DefaultClientProfile>
    {
    }
}