// <copyright file="ServiceCollectionExtensionsTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    using FactoryFoundation;
    using Microsoft.Extensions.DependencyInjection;
    using Polly;
    using Polly.Timeout;
    using SimpleServiceClient.Registration;
    using SimpleServiceClient.Tests.TestProfileService;
    using SimpleServiceClient.Tests.TestProfileTranslatedService;
    using SimpleServiceClient.Tests.TestService;
    using SimpleServiceClient.Tests.TestTranslatedService;
    using System.Reflection;

    /// <summary>
    /// Tests for the <see cref="ServiceCollectionExtensions"/> class.
    /// </summary>
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCollectionExtensionsTests"/> class.
        /// </summary>
        public ServiceCollectionExtensionsTests()
        {
            _services = new ServiceCollection();
        }

        /// <summary>
        /// Base service manager registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceManagerRegistersCorrectly()
        {
            _services.AddServiceManager();

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());
        }

        /// <summary>
        /// Base service manager with resilience pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceManagerWithResiliencePipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
                .AddTimeout(new TimeoutStrategyOptions()).Build();

            _services.AddServiceManager(pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());
        }

        /// <summary>
        /// Base service manager with client action registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceManagerWithProfileAndClientActionsRegistersCorrectly()
        {
            var baseUri = new Uri("https://www.test.com");

            _services.AddServiceManager<TestServiceProfile>(client =>
            {
                client.BaseAddress = baseUri;
            });

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            var profile = provider.GetRequiredService<TestServiceProfile>();

            Assert.IsNotNull(profile);

            Assert.AreEqual(baseUri, profile.Client.BaseAddress);
        }

        /// <summary>
        /// Base service manager with client action and resilience pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceManagerWithProfileClientActionsAndPipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            var baseUri = new Uri("https://www.test.com");

            _services.AddServiceManager<TestServiceProfile>(
                client =>
                {
                    client.BaseAddress = baseUri;
                },
                pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            var profile = provider.GetRequiredService<TestServiceProfile>();

            Assert.IsNotNull(profile);

            Assert.AreEqual(baseUri, profile.Client.BaseAddress);
        }

        /// <summary>
        /// Add service client registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceClientRegistersCorrectly()
        {
            _services.AddServiceClient<ITestServiceClient, TestServiceClient>();

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<ITestServiceClient>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());
        }

        /// <summary>
        /// Add service registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceRegistersCorrectly()
        {
            _services.AddServiceClient<TestServiceClient>();

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceClient>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());
        }

        /// <summary>
        /// Add service client with pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceClientWithPipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddServiceClient<ITestServiceClient, TestServiceClient>(pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<ITestServiceClient>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());
        }

        /// <summary>
        /// Add service with pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceWithPipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddServiceClient<TestServiceClient>(pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceClient>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());
        }

        /// <summary>
        /// Add service client with profile and client action registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceClientWithProfileAndClientActionRegistersCorrectly()
        {
            var uri = new Uri("https://www.test.com");

            _services.AddServiceClient<ITestServiceWithProfile, TestServiceWithProfile, TestServiceProfile>(client =>
            {
                client.BaseAddress = uri;
            });

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestServiceWithProfile>());
        }

        /// <summary>
        /// Add service with profile and client action registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceWithProfileAndClientActionsRegistersCorrectly()
        {
            var uri = new Uri("https://www.test.com");

            _services.AddServiceClient<TestServiceWithProfile, TestServiceProfile>(client =>
            {
                client.BaseAddress = uri;
            });

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceWithProfile>());
        }

        /// <summary>
        /// Add service client with profile, pipeline, and client action registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceClientWithProfilePipelineAndClientActionRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            var uri = new Uri("https://www.test.com");

            _services.AddServiceClient<ITestServiceWithProfile, TestServiceWithProfile, TestServiceProfile>(
                client =>
            {
                client.BaseAddress = uri;
            },
                pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestServiceWithProfile>());
        }

        /// <summary>
        /// Add service with profile and client action registers correctly.
        /// </summary>
        [TestMethod]
        public void AddServiceWithProfilePipelineAndClientActionRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            var uri = new Uri("https://www.test.com");

            _services.AddServiceClient<TestServiceWithProfile, TestServiceProfile>(
                client =>
                {
                    client.BaseAddress = uri;
                },
                pipeline);

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestServiceWithProfile>());
        }

        /// <summary>
        /// Add translation service client registers correctly.
        /// </summary>
        [TestMethod]
        public void AddTranslationServiceClientRegistersCorrectly()
        {
            _services.AddTranslatedServiceClient<ITestTranslationService, TestTranslationService>(Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestTranslationService>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translation service registers correctly.
        /// </summary>
        [TestMethod]
        public void AddTranslationServiceRegistersCorrectly()
        {
            _services.AddTranslatedServiceClient<TestTranslationService>(Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslationService>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service client with pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceClientWithPipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddTranslatedServiceClient<ITestTranslationService, TestTranslationService>(pipeline, Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestTranslationService>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service with pipeline registers correctly.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceWithPipelineRegistersCorrectly()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddTranslatedServiceClient<TestTranslationService>(pipeline, Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<DefaultClientProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager>());

            Assert.IsNotNull(provider.GetRequiredService<DefaultClientProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslationService>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service client with custom client implementation.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceClientWithProfileAndClientAction()
        {
            _services.AddTranslatedServiceClient<ITestTranslatedServiceWithProfile, TestTranslatedServiceWithProfile, TestTranslatedServiceProfile>(
                client =>
            {
                client.BaseAddress = new Uri("https://www.test.com");
            },
                Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestTranslatedServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestTranslatedServiceWithProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service with custom client implementation.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceWithProfileAndClientAction()
        {
            _services.AddTranslatedServiceClient<TestTranslatedServiceWithProfile, TestTranslatedServiceProfile>(
                client =>
                {
                    client.BaseAddress = new Uri("https://www.test.com");
                },
                Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestTranslatedServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceWithProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service client with resilience pipeline and custom client implementation.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceClientWithProfilePipelineAndClientAction()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddTranslatedServiceClient<ITestTranslatedServiceWithProfile, TestTranslatedServiceWithProfile, TestTranslatedServiceProfile>(
                client =>
                {
                    client.BaseAddress = new Uri("https://www.test.com");
                },
                pipeline,
                Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestTranslatedServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITestTranslatedServiceWithProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }

        /// <summary>
        /// Add translated service with resilience pipeline and custom client implementation.
        /// </summary>
        [TestMethod]
        public void AddTranslatedServiceWithProfilePipelineAndClientAction()
        {
            var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

            _services.AddTranslatedServiceClient<TestTranslatedServiceWithProfile, TestTranslatedServiceProfile>(
                client =>
                {
                    client.BaseAddress = new Uri("https://www.test.com");
                },
                pipeline,
                Assembly.GetExecutingAssembly());

            var provider = _services.BuildServiceProvider();

            Assert.IsNotNull(provider.GetRequiredService<IServiceManager<TestTranslatedServiceProfile>>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceProfile>());

            Assert.IsNotNull(provider.GetRequiredService<TestTranslatedServiceWithProfile>());

            Assert.IsNotNull(provider.GetRequiredService<ITranslator>());
        }
    }
}