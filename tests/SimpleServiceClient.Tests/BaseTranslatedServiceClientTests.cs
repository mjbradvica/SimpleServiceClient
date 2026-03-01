// <copyright file="BaseTranslatedServiceClientTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    using FactoryFoundation;
    using Microsoft.Extensions.Logging;
    using Moq;
    using SimpleServiceClient.Tests.TestProfileTranslatedService;
    using System.Net;
    using System.Net.Http.Json;

    /// <summary>
    /// Tests for the <see cref="BaseTranslatedServiceClient{TProfile}"/> class.
    /// </summary>
    [TestClass]
    public class BaseTranslatedServiceClientTests
    {
        private readonly Mock<ITranslator> _translator;
        private readonly Mock<IServiceManager<TestTranslatedServiceProfile>> _serviceManger;
        private readonly Mock<ILogger<BaseServiceClient<TestTranslatedServiceProfile>>> _logger;
        private TestTranslatedServiceWithProfile _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClientTests"/> class.
        /// </summary>
        public BaseTranslatedServiceClientTests()
        {
            _translator = new Mock<ITranslator>();
            _serviceManger = new Mock<IServiceManager<TestTranslatedServiceProfile>>();
            _logger = new Mock<ILogger<BaseServiceClient<TestTranslatedServiceProfile>>>();
            _service = new TestTranslatedServiceWithProfile(_serviceManger.Object, _logger.Object, _translator.Object);
        }

        /// <summary>
        /// Exceptions flag is passed correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ThrowFlagIsPassedCorrectly()
        {
            _service = new TestTranslatedServiceWithProfile(_serviceManger.Object, _logger.Object, _translator.Object, true);

            _serviceManger.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ThrowsAsync(new ArgumentNullException());

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.TestNewGet());
        }

        /// <summary>
        /// NullableGet with null returns default.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetNullResultHasDefault()
        {
            _serviceManger.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create<string?>(null),
                });

            string? result = await _service.TestNullableGet();

            Assert.IsNull(result);
        }

        /// <summary>
        /// NullableGet with success returns translated object.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteNullableGetSuccessTranslatesCorrectly()
        {
            _serviceManger.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create<string?>(string.Empty),
                });

            _translator.Setup(translator => translator.Translate<string?, string?>(It.IsAny<string?>()))
                .Returns(string.Empty);

            string? result = await _service.TestNullableGet();

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Get for default constructor translates correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultConstructorTranslatesCorrectly()
        {
            _serviceManger.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create<TestNewResponse?>(new TestNewResponse()),
                });

            _translator.Setup(translator => translator.Translate<TestNewResponse, TestNewResponse>(It.IsAny<TestNewResponse>()))
                .Returns(new TestNewResponse());

            var result = await _service.TestNewGet();

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Get for default response translates correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteDefaultResponseTranslatesCorrectly()
        {
            _serviceManger.Setup(manager => manager.GetAsync(It.IsAny<Uri>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create<TestNewResponse?>(new TestNewResponse()),
                });

            _translator.Setup(translator => translator.Translate<TestNewResponse, TestNewResponse>(It.IsAny<TestNewResponse>()))
                .Returns(new TestNewResponse());

            var result = await _service.TestDefaultResponseGet();

            Assert.IsNotNull(result);
        }
    }
}