// <copyright file="ServiceCollectionExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Registration
{
    using Microsoft.Extensions.DependencyInjection;
    using Polly;
    using SimpleServiceClient.Abstractions;
    using SimpleServiceClient.Clients;

    /// <summary>
    /// Extension methods that allow for easy registration of the SimpleServiceClient library.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers a service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <typeparam name="TProfile">The type of the service profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        public static void AddServiceClient<TClient, TImplementation, TProfile>(this IServiceCollection services, Action<HttpClient> clientAction)
           where TClient : class
           where TImplementation : BaseServiceClient<TProfile>, TClient
           where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction);

            services.AddTransient<TClient, TImplementation>();
        }

        /// <summary>
        /// Registers a service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <typeparam name="TProfile">The type of the service profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        public static void AddServiceClient<TClient, TImplementation, TProfile>(this IServiceCollection services, Action<HttpClient> clientAction, ResiliencePipeline<HttpResponseMessage> pipeline)
            where TClient : class
            where TImplementation : BaseServiceClient<TProfile>, TClient
            where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction).AddPolicyHandler(pipeline.AsAsyncPolicy());

            services.AddTransient<TClient, TImplementation>();
        }
    }
}