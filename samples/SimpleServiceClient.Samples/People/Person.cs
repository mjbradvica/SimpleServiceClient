// <copyright file="Person.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Samples.People
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sample person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets the birth year.
        /// </summary>
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; init; } = string.Empty;

        /// <summary>
        /// Gets the height.
        /// </summary>
        public string Height { get; init; } = string.Empty;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name} - {Height} - {BirthYear}";
        }
    }
}