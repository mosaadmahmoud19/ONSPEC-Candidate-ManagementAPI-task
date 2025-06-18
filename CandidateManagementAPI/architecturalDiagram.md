graph TD
    A[Swagger UI] --> B[Controller Layer]
    B --> C[Service Layer]
    C -->|Uses| D[Repository Layer]
    D --> E[(SQL Server DB)]
    C --> F[IMemoryCache]
    B --> G[DTOs]
    C --> G
    D --> H[Entity Models]
    G -->|Mapped by| I[AutoMapper]
