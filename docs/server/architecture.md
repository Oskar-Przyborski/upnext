# Server Architecture

## It's a Monolth.

It uses Hexagonal Architecture that consists of

- Core
    - **Upnext.Domain** - Aggregate Roots and Entities. The domain of the system.
    - **Upnext.Application** - Use Cases and implementations. 
        - Inputs - The UseCases definitions.
        - Outputs - Interfaces needed by implementations.
        - Implementations - implementations of usecases.
- Adapters
    - **Upnext.Postgres** - Entity Framework & Postgres implementation of repositories and UnitOfWork.
- Apps
    - **Upnext.WebApi** - Main entrypoint of the server. Configures adapters and application, and exposes HTTP REST interface.
