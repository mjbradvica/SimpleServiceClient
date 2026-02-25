// <copyright file="DefaultServiceManagerTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    /// <summary>
    /// Tests for the <see cref="ServiceManager"/> class.
    /// </summary>
    [TestClass]
    public class DefaultServiceManagerTests
    {
        /// <summary>
        /// Default service manager passes profile.
        /// </summary>
        [TestMethod]
        public void DefaultServiceManagerPassesProfileCorrectly()
        {
            var manager = new ServiceManager(new DefaultClientProfile(new HttpClient()));

            Assert.IsNotNull(manager);
        }
    }
}