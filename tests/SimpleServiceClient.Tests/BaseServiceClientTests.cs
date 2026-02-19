// <copyright file="BaseServiceClientTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using SimpleServiceClient.Tests.TestService;
    using System.Net;
    using System.Net.Http.Json;

    /// <summary>
    /// Tests for the <see cref="BaseServiceClient{TProfile}"/> class.
    /// </summary>
    [TestClass]
    public class BaseServiceClientTests
    {
        private readonly Mock<IServiceManager<TestProfile>> _serviceManager;
        private readonly TestServiceClient _serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClientTests"/> class.
        /// </summary>
        public BaseServiceClientTests()
        {
            _serviceManager = new Mock<IServiceManager<TestProfile>>();
            var logger = new Mock<ILogger<BaseServiceClient<TestProfile>>>();
            _serviceClient = new TestServiceClient(_serviceManager.Object, logger.Object);
        }

        /// <summary>
        /// Non-success response code returns default value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task NonSuccessCodeReturnsDefault()
        {
            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            string? result = await _serviceClient.GetValue<string>();

            Assert.IsNull(result);
        }

        /// <summary>
        /// Success response code returns expected value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task SuccessCodeReturnsCorrectValue()
        {
            var expected = new TestResponse
            {
                Name = "Hello!",
            };

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    Content = JsonContent.Create(expected),
                    StatusCode = HttpStatusCode.OK,
                });

            var result = await _serviceClient.GetValue<TestResponse>();

            Assert.AreEqual(expected.Name, result?.Name);
        }
    }
}