// <copyright file="DefaultBaseServiceClient.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    /// <inheritdoc />
    /// Same class name for simplicity of API.
    #pragma warning disable SA1649 // File name should match first type name
    public abstract class BaseServiceClient : BaseServiceClient<DefaultClientProfile>
    #pragma warning restore SA1649 // File name should match first type name
    {
        /// <inheritdoc />
        protected BaseServiceClient(IServiceManager<DefaultClientProfile> serviceManager)
            : base(serviceManager)
        {
        }
    }
}