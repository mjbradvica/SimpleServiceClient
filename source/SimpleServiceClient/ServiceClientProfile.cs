// <copyright file="ServiceClientProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    /// <summary>
    /// Designator for a service client profile.
    /// </summary>
    public abstract class ServiceClientProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientProfile"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the <see cref="HttpClient"/> class.</param>
        protected ServiceClientProfile(HttpClient httpClient)
        {
            Client = httpClient;
        }

        /// <summary>
        /// Gets the http client.
        /// </summary>
        public HttpClient Client { get; }
    }
}