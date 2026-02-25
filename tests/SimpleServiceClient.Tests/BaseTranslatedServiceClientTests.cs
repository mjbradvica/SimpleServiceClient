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
        private readonly TestTranslatedServiceWithProfile _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTranslatedServiceClientTests"/> class.
        /// </summary>
        public BaseTranslatedServiceClientTests()
        {
            _translator = new Mock<ITranslator>();
            _serviceManger = new Mock<IServiceManager<TestTranslatedServiceProfile>>();
            var logger = new Mock<ILogger<BaseServiceClient<TestTranslatedServiceProfile>>>();
            _service = new TestTranslatedServiceWithProfile(_serviceManger.Object, logger.Object, _translator.Object);
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
    }
}