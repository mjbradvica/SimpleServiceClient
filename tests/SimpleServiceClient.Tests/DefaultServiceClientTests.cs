// <copyright file="DefaultServiceClientTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    /// <summary>
    /// Tests for the <see cref="DefaultClientProfile"/> class.
    /// </summary>
    [TestClass]
    public class DefaultServiceClientTests
    {
        /// <summary>
        /// Default client profile passes client correctly.
        /// </summary>
        [TestMethod]
        public void ConstructorPassesClientCorrectly()
        {
            var client = new HttpClient();

            var profile = new DefaultClientProfile(client);

            Assert.AreEqual(client, profile.Client);
        }
    }
}