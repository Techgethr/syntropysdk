# Syntropy SDK for .NET Framework
.NET Framework Library for Syntropy Stack (https://www.syntropystack.com/), built with C#

## License
----
MIT

## Contributors
----

- [Néstor Nicolás Campos Rojas](https://www.linkedin.com/in/nescampos/)
- [Techgethr SpA](https://techgethr.com/)

## Use the library

You can use this library since .NET Framework version 4.5 or superior.
To consume this library, just add with NuGet or DotNet CLI in your project.

**Full version**

```sh
    Install-Package SyntropySDK -Version 1.0.0
```

```sh
    dotnet add package SyntropySDK --version 1.0.0
```

## Configuration

You need to initialized the service with **SyntropyConfigurator** class, with your JWT token as parameter.

```csharp
    SyntropyConfigurator.Init("jwt")
```

### Dependencies

The only dependency is [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

## Public

You can use *public* service (**HealthService**) for getting data like "Health".

```csharp
    using SyntropySDK.Public
    HealthService.Get()
```

**Static Methods**:
- Get()

## Platform

### LogService
You can use *log* service (**LogService**) for getting data about logs.

```csharp
    using SyntropySDK.Platform
    LogService.SaveLogsTimestamp()
```

**Static Methods**:
- SaveLogsTimestamp()


### AgentService
You can use *agent* service (**AgentService**) for getting data and configure agents.

```csharp
    using SyntropySDK.Platform
    AgentService.GetAgentProviders()
```

**Static Methods**:
- GetAgentProviders()
- GetAgentProvider()
- GetAgentConfiguration()
- GetAgentWireGuardConfiguration()
- GetAgents()
- GetAgentServices()
- GetAgentsByFilters()
- GetAgentTags()
- GetAgentCoordinates()
- UpdateStatus()
- DeleteAgentServices()
- CreateAgent()


### ConnectionService
You can use *connection* service (**ConnectionService**) for getting data and configure connections.

```csharp
    using SyntropySDK.Platform
    ConnectionService.RemoveConnection()
```

**Static Methods**:
- RemoveConnection()
- RemoveAgentConnection()
- DeleteAgentConnection()
- UpdateAgentConnection()
- GetConnections()
- PointToPoint()
- Mesh()

### NetworkService
You can use *network* service (**NetworkService**) for getting data and configure networks.

```csharp
    using SyntropySDK.Platform
    NetworkService.CreateNetwork()
```

**Static Methods**:
- CreateNetwork()
- GetNetworks()
- GetTopology()
- DeleteNetwork()
- AddAgents()
- RemoveAgents()


## Contributions

If you want to colaborate, just fork this repository and build new things. Thanks!!
