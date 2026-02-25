// <copyright file="TestPost.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests.TestService
{
    /// <summary>
    /// Test response.
    /// </summary>
    public class TestPost
    {
        /// <summary>
        /// Gets the test identifier.
        /// </summary>
        public int Id { get; init; } = 1;

        /// <summary>
        /// Gets the test title.
        /// </summary>
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// Gets the test body.
        /// </summary>
        public string Body { get; init; } = string.Empty;

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public int UserId { get; init; } = 1;
    }
}