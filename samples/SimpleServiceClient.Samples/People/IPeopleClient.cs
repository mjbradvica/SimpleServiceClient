// <copyright file="IPeopleClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.People
{
    /// <summary>
    /// Sample person client.
    /// </summary>
    public interface IPeopleClient
    {
        /// <summary>
        /// Attempts to retrieve a person.
        /// </summary>
        /// <param name="personId">The identifier of the person.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Person?> GetPerson(int personId, CancellationToken cancellationToken = default);
    }
}