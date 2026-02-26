# SimpleServiceClient

A middle ground solution for HTTP service clients.

![TempIcon](https://i.imgur.com/KBZKt7T.png)

![build-status](https://github.com/mjbradvica/SimpleServiceClient/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/SimpleServiceClient) ![nuget](https://img.shields.io/nuget/v/SimpleServiceClient) ![activity](https://img.shields.io/github/last-commit/mjbradvica/SimpleServiceClient/master)

## Overview

- :mirror: - Interface for the HTTP client
- :muscle: - Flexible options for customization
- :robot: - Zero code generation & fully typed
- :test_tube: - Built for unit testing
- :parrot: - Easy integration with Polly

## Family

SimpleServiceClient is a member of the Simplex Software family of libraries. Simplex Software libraries form the foundation for great software. Many Simplex Software libraries enhance each other to help bring your ideas to life.

## Samples

If you would like code samples for SimpleServiceClient, they can be found [here in the documentation](https://github.com/mjbradvica/SimpleServiceClient/tree/master/samples/SimpleServiceClient.Samples).

## Dependencies

SimpleServiceClient depends on the following:

- [Polly](https://www.pollydocs.org/index.html) - Resilience strategies for HTTP clients.
- [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly/) - Integrates Polly into the IHttpClientFactory and HttpClient.
- [FactoryFoundation](https://github.com/mjbradvica/FactoryFoundation) - Allows for easy mapping from clients.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/packages/SimpleServiceClient/).

Install where you need with:

```bash
Install-Package SimpleServiceClient
```

## Setup

SimpleServiceClient has multiple ways to integrate into the DI container.

The method you use to register your clients depends on the following:

1) Are you using a profile to configure the HttpClient?
2) Will you be using Polly resilience strategies?
3) Are you using a client interface? (highly recommended)
4) Do you need to map your responses to a different object?

The following examples shows the "most likely" scenario for clients.

```csharp
// Add your needed strategies.
var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

service.AddServiceClient<MyClientInterface, MyServiceClient, MyClientProfile>(x => 
    {
        x.BaseUri = new Uri("https://www.service.com");
    },
    pipeline);
```

...or if you are using a service that maps responses.

```csharp
// Add your needed strategies.
var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>().Build();

service.AddTranslatedServiceClient<MyClientInterface, MyServiceClient, MyClientProfile>(x => 
    {
        x.BaseUri = new Uri("https://www.service.com");
    },
    pipeline,
    Assembly.GetExecutingAssembly());
```

## Quick Start

## Detailed Usage

## FAQ

### What is SimpleServiceClient?

SimpleServiceClient is a "middle ground" between rolling your own code for interfacing with HTTP based services and relying on libraries that are generating a bunch of code that you don't understand.

SSC gives you a third option where all the annoying boilerplate is already written and tested. You just need to plug in the pieces you need.

### Does SSC generate anything?

No, SSC is fully-typed and relies on interfaces and base classes to accomplish all of its goals.

The advantage of this is your have much more insight into what is going on for service calls.

### Is Polly required?

No, you can use SSC without Polly. However, Polly is great at what it does and is highly recommended.

### Do I have to use FactoryFoundation to map objects?

You don't have to use FactoryFoundation to do the actual mapping. But you do need to tunnel whatever mapping process into the appropriate interface.

However, it is highly recommended to use FactoryFoundation to avoid runtime errors with mapping.