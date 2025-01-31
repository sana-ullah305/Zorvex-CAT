# Zorvex-CAT

Zorvex-CAT is a C# API project following the CQRS, DDD, SOLID principles with Dapper for data access and basic authentication. The project is built using **.NET Core 9** and follows Clean Architecture to ensure separation of concerns and maintainability. This version avoids using Entity Framework, making it a lightweight and high-performance solution.

## Project Structure

```
- Api (Presentation Layer)
- Application (Commands/Queries, DTOs)
- Domain (Models, Interfaces)
- Infrastructure (Dapper Implementation)
```

## Key Features

- **CQRS Pattern**: Clear separation between commands (write) and queries (read) using MediatR.
- **Clean Architecture**: Structured layers for better maintainability and scalability.
- **Dapper**: Lightweight data access tool for faster and more efficient SQL queries.
- **Authentication**: Basic authentication using BCrypt for password hashing.
- **SOLID Principles**: Ensures the project follows clean coding practices for better extensibility and maintainability.

---

## Setup Instructions

1. **Create SQL Table**:
```sql
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL
)
```

2. **Add connection string**:
```json
"ConnectionStrings": {
  "Default": "Server=.;Database=MyApp;Integrated Security=True;TrustServerCertificate=True"
}
```

3. **Run the Application**:
    - Clone the repository.
    - Build the solution.
    - Run the application using `dotnet run` and test the API endpoints.

---

## License

This project is licensed under the **MIT License**.

---

## Contributing

Feel free to open issues or submit pull requests for any improvements or bug fixes. All contributions are welcome.

---

## Acknowledgments

This project uses:
- **Dapper**: For efficient data access.
- **MediatR**: To implement the mediator pattern.
- **BCrypt.Net**: For password hashing.

---

## License

MIT License. See the [LICENSE](LICENSE) file for more details.