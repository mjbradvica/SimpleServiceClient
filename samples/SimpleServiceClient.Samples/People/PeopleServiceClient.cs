// <copyright file="PeopleServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.People
{
    /// <inheritdoc cref="IPeopleClient" />
    public class PeopleServiceClient : BaseServiceClient, IPeopleClient
    {
        /// <inheritdoc />
        public PeopleServiceClient(IServiceManager<DefaultClientProfile> serviceManager)
            : base(serviceManager)
        {
        }

        /// <inheritdoc/>
        public async Task<Person?> GetPerson(int personId, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<Person>(new Uri($"https://swapi.dev/api/people/{personId}"), cancellationToken);
        }
    }
}