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
        private readonly Mock<IServiceManager> _serviceManager;
        private readonly Mock<ILogger<BaseServiceClient>> _logger;
        private TestServiceClient _serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClientTests"/> class.
        /// </summary>
        public BaseServiceClientTests()
        {
            _serviceManager = new Mock<IServiceManager>();
            _logger = new Mock<ILogger<BaseServiceClient>>();
            _serviceClient = new TestServiceClient(_serviceManager.Object, _logger.Object);
        }

        /// <summary>
        /// Non-success response code returns default value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetNonSuccessCodeReturnsDefault()
        {
            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            string? result = await _serviceClient.NullableGet<string>();

            Assert.IsNull(result);
        }

        /// <summary>
        /// Success response code returns expected value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetSuccessCodeReturnsCorrectValue()
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

            var result = await _serviceClient.NullableGet<TestResponse>();

            Assert.AreEqual(expected.Name, result?.Name);
        }

        /// <summary>
        /// Default response is returned on exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetOnExceptionIsCaught()
        {
            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            var result = await _serviceClient.NullableGet<TestResponse>();

            Assert.IsNull(result);
        }

        /// <summary>
        /// Exception thrown when flag is enabled.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetThrowsOnCommand()
        {
            _serviceClient = new TestServiceClient(_serviceManager.Object, _logger.Object, true);

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            await Assert.ThrowsAsync<ArgumentException>(async () => await _serviceClient.NullableGet<TestResponse>());
        }

        /// <summary>
        /// New default response returns default on non-success response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNewDefaultGetNonSuccessCodeReturnsDefaultValue()
        {
            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var result = await _serviceClient.NewDefaultGet<TestResponse>();

            Assert.AreEqual(string.Empty, result.Name);
        }

        /// <summary>
        /// New default response has expected value on success.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNewDefaultSuccessReturnsExpected()
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

            var result = await _serviceClient.NewDefaultGet<TestResponse>();

            Assert.AreEqual(expected.Name, result.Name);
        }

        /// <summary>
        /// New default response has default response on exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNewDefaultOnExceptionReturnsExpectedValue()
        {
            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            var result = await _serviceClient.NewDefaultGet<TestResponse>();

            Assert.AreEqual(string.Empty, result.Name);
        }

        /// <summary>
        /// New default response throws when flag is enabled.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNewDefaultThrowsWhenFlagIsEnabled()
        {
            _serviceClient = new TestServiceClient(_serviceManager.Object, _logger.Object, true);

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            await Assert.ThrowsAsync<ArgumentException>(async () => await _serviceClient.NewDefaultGet<TestResponse>());
        }

        /// <summary>
        /// Default value get returns default on non-success code.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultValueGetNonSuccessCodeReturnsDefaultValue()
        {
            const string defaultValue = "hello!";

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            string result = await _serviceClient.DefaultValueGet(defaultValue);

            Assert.AreEqual(defaultValue, result);
        }

        /// <summary>
        /// Success has correct value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultValueGetSuccessReturnsExpected()
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

            var result = await _serviceClient.DefaultValueGet(new TestResponse());

            Assert.AreEqual(expected.Name, result.Name);
        }

        /// <summary>
        /// Default value is returned on an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultValueOnExceptionReturnsExpectedValue()
        {
            var expected = new TestResponse();

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            var result = await _serviceClient.DefaultValueGet(expected);

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Method throws when flag is enabled.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultValueThrowsWhenFlagEnabled()
        {
            _serviceClient = new TestServiceClient(_serviceManager.Object, _logger.Object, true);

            _serviceManager.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentException());

            await Assert.ThrowsAsync<ArgumentException>(async () => await _serviceClient.DefaultValueGet(new TestResponse()));
        }
    }
}