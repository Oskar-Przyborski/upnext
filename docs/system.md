# System Design Principles

## No User Accounts

upnext intentionally avoids user accounts to keep the system lightweight and easy to deploy.

All data stored in the database is shared across anyone with access to the server instance.

Security is therefore delegated to the hosting environment. You are responsible for:

- securing the server and network
- restricting access to trusted users
- configuring authentication at the infrastructure level if needed (VPN, reverse proxy, etc.)

This design keeps the application simple, fast, and fully self-hosted.

## Domain Model

### Todo Items

A `TodoItem` is the primary entity of the system. 

Each TodoItem contains:

- Name — short, human-readable title
- Description — optional detailed information
- Deadline — optional due date
- Status - one of Todo, In Progress or Done
- Priority - one of Lowest, Low, Medium, High, Critical
- Tags — zero or more categories used for grouping and filtering

### Tags

A `Tag` is a lightweight categorization label for TodoItems.

Each tag contains:

- Name
- Color

Tags allow TodoItems to be grouped, filtered, and visually distinguished.
