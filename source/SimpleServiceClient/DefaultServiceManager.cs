// <copyright file="DefaultServiceManager.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace SimpleServiceClient
{
    /// <inheritdoc cref="IServiceManager" />
    /// Common file name for simplicity.
#pragma warning disable SA1649 // File name should match first type name
    public class ServiceManager : ServiceManager<DefaultClientProfile>, IServiceManager
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <inheritdoc />
        public ServiceManager(DefaultClientProfile profile)
            : base(profile)
        {
        }
    }
}