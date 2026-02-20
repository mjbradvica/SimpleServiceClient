// <copyright file="ServiceCollectionExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient.Registration
{
    using FactoryFoundation;
    using Microsoft.Extensions.DependencyInjection;
    using Polly;
    using SimpleServiceClient;
    using System.Reflection;

    /// <summary>
    /// Extension methods that allow for easy registration of the SimpleServiceClient library.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers only the service manager to the container using the default profile.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        public static void AddServiceManager(this IServiceCollection services)
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddHttpClient<DefaultClientProfile>();
        }

        /// <summary>
        /// Registers only the service manager to the container using the default profile.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        public static void AddServiceManager(this IServiceCollection services, ResiliencePipeline<HttpResponseMessage> pipeline)
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddHttpClient<DefaultClientProfile>().AddPolicyHandler(pipeline.AsAsyncPolicy());
        }

        /// <summary>
        /// Registers only the service manager to the container using the default profile.
        /// </summary>
        /// <typeparam name="TProfile">The type of the profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        public static void AddServiceManager<TProfile>(this IServiceCollection services, Action<HttpClient> clientAction)
            where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction);
        }

        /// <summary>
        /// Registers only the service manager to the container using the default profile.
        /// </summary>
        /// <typeparam name="TProfile">The type of the profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        public static void AddServiceManager<TProfile>(this IServiceCollection services, Action<HttpClient> clientAction, ResiliencePipeline<HttpResponseMessage> pipeline)
            where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction).AddPolicyHandler(pipeline.AsAsyncPolicy());
        }

        /// <summary>
        /// Registers a service client to the container using the default profile.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        public static void AddServiceClient<TClient, TImplementation>(this IServiceCollection services)
            where TClient : class
            where TImplementation : BaseServiceClient<DefaultClientProfile>, TClient
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddTransient<TClient, TImplementation>();

            services.AddHttpClient<DefaultClientProfile>();
        }

        /// <summary>
        /// Registers a service client to the container using the default profile.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        public static void AddServiceClient<TClient, TImplementation>(this IServiceCollection services, ResiliencePipeline<HttpResponseMessage> pipeline)
            where TClient : class
            where TImplementation : BaseServiceClient<DefaultClientProfile>, TClient
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddTransient<TClient, TImplementation>();

            services.AddHttpClient<DefaultClientProfile>().AddPolicyHandler(pipeline.AsAsyncPolicy());
        }

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

        /// <summary>
        /// Registers a translated service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="assemblies">An <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register factories for.</param>
        public static void AddTranslatedServiceClient<TClient, TImplementation>(this IServiceCollection services, params Assembly[] assemblies)
            where TClient : class
            where TImplementation : BaseTranslatedServiceClient<DefaultClientProfile>, TClient
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddHttpClient<DefaultClientProfile>();

            services.AddTransient<TClient, TImplementation>();

            services.AddFactoryFoundation(assemblies);
        }

        /// <summary>
        /// Registers a translated service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        /// <param name="assemblies">An <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register factories for.</param>
        public static void AddTranslatedServiceClient<TClient, TImplementation>(this IServiceCollection services, ResiliencePipeline<HttpResponseMessage> pipeline, params Assembly[] assemblies)
            where TClient : class
            where TImplementation : BaseTranslatedServiceClient<DefaultClientProfile>, TClient
        {
            services.AddTransient<IServiceManager<DefaultClientProfile>, ServiceManager<DefaultClientProfile>>();

            services.AddHttpClient<DefaultClientProfile>().AddPolicyHandler(pipeline.AsAsyncPolicy());

            services.AddTransient<TClient, TImplementation>();

            services.AddFactoryFoundation(assemblies);
        }

        /// <summary>
        /// Registers a translated service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <typeparam name="TProfile">The type of the service profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        /// <param name="assemblies">An <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register factories for.</param>
        public static void AddTranslatedServiceClient<TClient, TImplementation, TProfile>(this IServiceCollection services, Action<HttpClient> clientAction, params Assembly[] assemblies)
            where TClient : class
            where TImplementation : BaseTranslatedServiceClient<TProfile>, TClient
            where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction);

            services.AddTransient<TClient, TImplementation>();

            services.AddFactoryFoundation(assemblies);
        }

        /// <summary>
        /// Registers a translated service client to the container.
        /// </summary>
        /// <typeparam name="TClient">The type of the client interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the client implementation.</typeparam>
        /// <typeparam name="TProfile">The type of the service profile.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="clientAction">An <see cref="Action"/> to configure the <see cref="HttpClient"/>.</param>
        /// <param name="pipeline">An <see cref="ResiliencePipeline{T}"/> instance for policy registration.</param>
        /// <param name="assemblies">An <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register factories for.</param>
        public static void AddTranslatedServiceClient<TClient, TImplementation, TProfile>(this IServiceCollection services, Action<HttpClient> clientAction, ResiliencePipeline<HttpResponseMessage> pipeline, params Assembly[] assemblies)
            where TClient : class
            where TImplementation : BaseTranslatedServiceClient<TProfile>, TClient
            where TProfile : ServiceClientProfile
        {
            services.AddTransient<IServiceManager<TProfile>, ServiceManager<TProfile>>();

            services.AddHttpClient<TProfile>(clientAction).AddPolicyHandler(pipeline.AsAsyncPolicy());

            services.AddTransient<TClient, TImplementation>();

            services.AddFactoryFoundation(assemblies);
        }
    }
}