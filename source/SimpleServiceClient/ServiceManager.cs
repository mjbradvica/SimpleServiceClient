// <copyright file="ServiceManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    using SimpleServiceClient.Abstractions;

    /// <inheritdoc />
    public class ServiceManager : IServiceManager
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the <see cref="HttpClient"/> class.</param>
        public ServiceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
