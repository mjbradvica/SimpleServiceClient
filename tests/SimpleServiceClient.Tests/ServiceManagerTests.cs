// <copyright file="ServiceManagerTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Tests
{
    using SimpleServiceClient.Tests.TestProfileService;
    using SimpleServiceClient.Tests.TestService;
    using System.Net.Http.Json;

    /// <summary>
    /// Tests for the <see cref="ServiceManager{TProfile}"/> class.
    /// </summary>
    [TestClass]
    public class ServiceManagerTests
    {
        private static readonly Uri Uri = new Uri("https://jsonplaceholder.typicode.com/");
        private readonly ServiceManager<TestServiceProfile> _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManagerTests"/> class.
        /// </summary>
        public ServiceManagerTests()
        {
            var client = new HttpClient
            {
                BaseAddress = Uri,
            };

            _manager = new ServiceManager<TestServiceProfile>(new TestServiceProfile(client));
        }

        /// <summary>
        /// Can reach client.
        /// </summary>
        [TestMethod]
        public void ClientIsNotNull()
        {
            var client = _manager.HttpClient;

            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Get Async correct passes command.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetAsyncCallsCorrectly()
        {
            var result = await _manager.GetAsync(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Gets string async passes command.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetStringAsyncCallsCorrectly()
        {
            string result = await _manager.GetStringAsync(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Get stream async passes command.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetStreamAsyncCallsCorrectly()
        {
            var result = await _manager.GetStreamAsync(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Get byte array passes command.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByteArrayAsyncCallsCorrectly()
        {
            byte[] result = await _manager.GetByteArrayAsync(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Gets from json passes correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetFromJsonAsyncCallsCorrectly()
        {
            var result = await _manager.GetFromJsonAsync<TestPost>(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Post async passes correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PostAsyncCallsCorrectly()
        {
            var content = JsonContent.Create(new TestPost());

            var result = await _manager.PostAsync(new Uri("posts", UriKind.Relative), content, CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Post as json async passes correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PostAsJsonAsyncCallsCorrectly()
        {
            var result = await _manager.PostAsJsonAsync(new Uri("posts", UriKind.Relative), new TestPost(), CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Put async passes correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PutAsyncCallsCorrectly()
        {
            var content = JsonContent.Create(new TestPost());

            var result = await _manager.PutAsync(new Uri("posts/1", UriKind.Relative), content, CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Put as json async passes correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PutAsJsonAsyncCallsCorrectly()
        {
            var result = await _manager.PutAsJsonAsync(new Uri("posts/1", UriKind.Relative), new TestPost(), CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Patch async calls correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PatchAsyncCallsCorrectly()
        {
            var content = JsonContent.Create(new TestPost());

            var result = await _manager.PatchAsync(new Uri("posts/1", UriKind.Relative), content, CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Patch as json async calls correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PatchAsJsonAsyncCallsCorrectly()
        {
            var result = await _manager.PatchAsJsonAsync(new Uri("posts/1", UriKind.Relative), new TestPost(), CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Delete async calls correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteAsyncCallsCorrectly()
        {
            var result = await _manager.DeleteAsync(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Delete as json async calls correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteFromJsonAsyncCallsCorrectly()
        {
            var result = await _manager.DeleteFromJsonAsync<TestPost>(new Uri("posts/1", UriKind.Relative), CancellationToken.None);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Sends async calls correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task SendAsyncCallsCorrectly()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, new Uri("posts/1", UriKind.Relative));

            var result = await _manager.SendAsync(message, CancellationToken.None);

            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}