// <copyright file="PeopleServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.People
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="IPeopleClient" />
    public class PeopleServiceClient : BaseServiceClient, IPeopleClient
    {
        /// <inheritdoc />
        public PeopleServiceClient(IServiceManager<DefaultClientProfile> serviceManager, ILogger<BaseServiceClient<DefaultClientProfile>> logger)
            : base(serviceManager, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Person?> GetPerson(int personId, CancellationToken cancellationToken = default)
        {
            return await ExecuteNullableGet<Person>(new Uri($"https://swapi.dev/api/people/{personId}"), cancellationToken);
        }
    }
}