// <copyright file="PeopleServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.People
{
    using Microsoft.Extensions.Logging;

    /// <inheritdoc cref="IPeopleClient" />
    public class PeopleServiceClient : BaseServiceClient, IPeopleClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleServiceClient"/> class.
        /// </summary>
        /// <param name="serviceManager">An instance of the <see cref="IServiceManager"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        public PeopleServiceClient(IServiceManager serviceManager, ILogger<BaseServiceClient> logger)
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