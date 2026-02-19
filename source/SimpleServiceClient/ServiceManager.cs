// <copyright file="ServiceManager.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
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
    }
}